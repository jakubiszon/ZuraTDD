using ZuraTDD.Generator.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace ZuraTDD.Generator;

[Generator(LanguageNames.CSharp)]
public class TestSubjectSourceGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var classDeclarationsProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: (node, _) => node is ClassDeclarationSyntax,
				transform: (ctx, _) => (ClassDeclarationSyntax)ctx.Node)
			.Where(classDecl => classDecl is not null);

		var filesProvider = classDeclarationsProvider
			.Combine(context.CompilationProvider)
			.Where(PairRequiresCodeGeneration)
			.SelectMany((pair, _) => ProcessCandidateClass(pair))
			.WithComparer(new SourceFileComparer())
			.Collect();

		context.RegisterSourceOutput(
			filesProvider,
			(context, collected) =>
			{
				foreach (var group in collected.GroupBy(file => file.FileName))
				{
					var file = group.First();
					context.AddSource(file.FileName, file.GeneratorFunction());
				}
			});
	}

	/// <summary>
	/// Returns true if the specified pair represents only one of:
	/// <list type="bullet">
	/// <item>a class that implements ITestCase&lt;T&gt; interface</item>
	/// <item>a class that implements IMock&lt;T&gt; interface</item>
	/// </list>
	/// </summary>
	private bool PairRequiresCodeGeneration((ClassDeclarationSyntax, Compilation) pair)
	{
		var (classDecl, compilation) = pair;
		var testCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
		var mockInterface = compilation.GetTypeByMetadataName("ZuraTDD.IMock`1");

		if (testCaseInterface == null || mockInterface == null)
			return false;

		var model = compilation.GetSemanticModel(classDecl.SyntaxTree);
		var typeSymbol = model.GetDeclaredSymbol(classDecl) as INamedTypeSymbol;
				
		if (typeSymbol == null)
			return false;

		bool isTestCase = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, testCaseInterface));
		bool isMock = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, mockInterface));

		return isTestCase || isMock;
	}

	private bool IsSameInterface(INamedTypeSymbol interface1, INamedTypeSymbol? interface2)
	{
		if(interface2 == null)
			return false;

		return SymbolEqualityComparer
			.Default
			.Equals(interface1.OriginalDefinition, interface2);
	}

	private ImmutableArray<SourceFileGenerator> ProcessCandidateClass(
		(ClassDeclarationSyntax, Compilation) pair)
	{
		var (candidate, compilation) = pair;

		var model = compilation.GetSemanticModel(candidate.SyntaxTree);
		var typeSymbol = model.GetDeclaredSymbol(candidate) as INamedTypeSymbol;
	
		if (typeSymbol == null)
			return ImmutableArray<SourceFileGenerator>.Empty;

		// Get interfaces
		var testCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
		var mockInterface = compilation.GetTypeByMetadataName("ZuraTDD.IMock`1");

		bool isTestCase = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, testCaseInterface));
		bool isMock = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, mockInterface));
		var isPartial = candidate.Modifiers.Any(token => token.ValueText == "partial");

		if (isTestCase && isMock)
		{
			//OutputMultipleGeneratorsNotAllowedDiagnostic(context, candidate, typeSymbol);
			return ImmutableArray<SourceFileGenerator>.Empty;
		}

		if(!isPartial)
		{
			//string interfaceName = isTestCase ? "ITestCase<T>" : "IMock<T>";
			//OutputSymbolNotPartialDiagnostic(context, candidate, typeSymbol, interfaceName);
			return ImmutableArray<SourceFileGenerator>.Empty;
		}

		if (isTestCase)
		{
			return GenerateTestCaseCode(typeSymbol)
				.GetFilesToGenerate()
				.ToImmutableArray();
		}
		else if (isMock)
		{
			return GenerateMockCode(typeSymbol)
				.GetFilesToGenerate()
				.ToImmutableArray();
		}
		else
		{
			return ImmutableArray<SourceFileGenerator>.Empty;
		}
	}

	private SourceFilesToCreate GenerateTestCaseCode(
		INamedTypeSymbol typeSymbol)
	{
		SourceFilesToCreate files = new ();
		var testCaseSpecification = new TestCaseSpecification(typeSymbol);

		files.AddFile(
			$"{typeSymbol.Name}.generated.cs",
			TemplateProcessor.PrepareTestCaseClassCode,
			testCaseSpecification);

		files.AddFile(
			$"{testCaseSpecification.ServicesClass.ServicesClassName}.generated.cs",
			TemplateProcessor.PrepareServicesClassCode,
			testCaseSpecification.ServicesClass);

		foreach (var service in testCaseSpecification.ServicesClass.Services)
		{
			files.AddFile(
				$"{service.ServiceMethodsTypeName}.generated.cs",
				TemplateProcessor.ServiceMethodsClassCode,
				service);

			files.AddFile(
				$"{service.ServiceTypeName}_Builders.generated.cs",
				TemplateProcessor.ServiceBuilderClassesCode,
				service);

			files.AddFile(
				$"{service.ServiceTypeName}_StaticBuilder.generated.cs",
				TemplateProcessor.ServiceStaticBuilderCode,
				service);

			files.AddFile(
				$"{service.ServiceTypeName}_Fake.generated.cs",
				TemplateProcessor.GenerateFakeServiceCode,
				service);

			files.AddFile(
				$"{service.ServiceTypeName}_Expect.generated.cs",
				TemplateProcessor.GenerateExpectServiceCode,
				service);
		}

		return files;
	}

	private SourceFilesToCreate GenerateMockCode(
		INamedTypeSymbol typeSymbol)
	{
		SourceFilesToCreate files = new ();
		var mockSpecification = new MockObjectSpecification(typeSymbol);
		var mockedType = mockSpecification.MockedTypeSpecification;

		files.AddFile(
			$"{mockedType.ServiceMethodsTypeName}.generated.cs",
			TemplateProcessor.ServiceMethodsClassCode,
			mockedType);

		files.AddFile(
			$"{mockedType.ServiceTypeName}_Builders.generated.cs",
			TemplateProcessor.ServiceBuilderClassesCode,
			mockedType);

		files.AddFile(
			$"{mockedType.ServiceTypeName}_Fake.generated.cs",
			TemplateProcessor.GenerateFakeServiceCode,
			mockedType);

		files.AddFile(
			$"{mockedType.ServiceTypeName}_Expect.generated.cs",
			TemplateProcessor.GenerateExpectServiceCode,
			mockedType);

		files.AddFile(
			$"{mockSpecification.TypeName}.generated.cs",
			TemplateProcessor.GenerateMockCode,
			mockSpecification);

		return files;
	}

	private void OutputSymbolNotPartialDiagnostic(
		SourceProductionContext context,
		ClassDeclarationSyntax candidate,
		INamedTypeSymbol candidateTypeSymbol,
		string interfaceName)
	{
		var location = candidate.GetLocation();

		context.ReportDiagnostic(Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "SG0001",
				title: $"A class implementing {interfaceName} must be partial.",
				messageFormat: $"Type '{{0}}' implements {interfaceName} and must be declared as 'partial'.",
				category: "ZuraTDD",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true),
			location,
			candidateTypeSymbol.Name));
	}

	private void OutputMultipleGeneratorsNotAllowedDiagnostic(
		SourceProductionContext context,
		ClassDeclarationSyntax candidate,
		INamedTypeSymbol candidateTypeSymbol)
	{
		var location = candidate.GetLocation();
		context.ReportDiagnostic(Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "SG0003",
				title: "A class cannot implement ITestCase<T> and IMock<T> at the same time.",
				messageFormat: "Type '{0}' is implementing ITestCase<T> and IMock<T> which is not allowed.",
				category: "ZuraTDD",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true),
			location,
			candidateTypeSymbol.Name));
	}
}

internal class SourceFileComparer : IEqualityComparer<SourceFileGenerator>
{
	public bool Equals(SourceFileGenerator x, SourceFileGenerator y)
	{
		if (ReferenceEquals(x, y))
			return true;

		if (x is null || y is null)
			return false;

		return x.FileName == y.FileName;
	}

	public int GetHashCode(SourceFileGenerator obj)
	{
		return obj.FileName.GetHashCode();
	}
}