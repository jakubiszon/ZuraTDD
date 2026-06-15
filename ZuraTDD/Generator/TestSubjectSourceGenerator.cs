using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ZuraTDD.Generator.DataModel;

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

	//TODO: change result type to allow outputting diagnostics from this method
	private ImmutableArray<SourceFileToGenerate> ProcessCandidateClass(
		(ClassDeclarationSyntax, Compilation) pair)
	{
		var (candidate, compilation) = pair;

		var model = compilation.GetSemanticModel(candidate.SyntaxTree);
		var typeSymbol = model.GetDeclaredSymbol(candidate) as INamedTypeSymbol;
	
		if (typeSymbol == null)
			return ImmutableArray<SourceFileToGenerate>.Empty;

		// Get interfaces
		var testCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
		var mockInterface = compilation.GetTypeByMetadataName("ZuraTDD.IMock`1");

		bool isTestCase = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, testCaseInterface));
		bool isMock = typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, mockInterface));
		var isPartial = candidate.Modifiers.Any(token => token.ValueText == "partial");

		if (isTestCase && isMock)
		{
			// TODO restore diagnostics
			//OutputMultipleGeneratorsNotAllowedDiagnostic(context, candidate, typeSymbol);
			return ImmutableArray<SourceFileToGenerate>.Empty;
		}

		if(!isPartial)
		{
			// TODO restore diagnostics
			//string interfaceName = isTestCase ? "ITestCase<T>" : "IMock<T>";
			//OutputSymbolNotPartialDiagnostic(context, candidate, typeSymbol, interfaceName);
			return ImmutableArray<SourceFileToGenerate>.Empty;
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
			return ImmutableArray<SourceFileToGenerate>.Empty;
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
			$"{testCaseSpecification.DependenciesClass.DependenciesClassName}.generated.cs",
			TemplateProcessor.PrepareTestSubjectDependenciesClassCode,
			testCaseSpecification.DependenciesClass);

		foreach (var dependency in testCaseSpecification.DependenciesClass.Dependencies)
		{
			var filesToAdd = GenerateDependencyCode(dependency);
			files.AddFiles(filesToAdd.GetFilesToGenerate());
		}

		return files;
	}

	private SourceFilesToCreate GenerateMockCode(
		INamedTypeSymbol typeSymbol)
	{
		var mockSpecification = new MockObjectSpecification(typeSymbol);
		var dependencySpecification = mockSpecification.MockedTypeSpecification;

		SourceFilesToCreate files = new ();

		files.AddFile(
			$"{dependencySpecification.MockedTypeMethodsTypeName}.generated.cs",
			TemplateProcessor.MockedTypeMethodsClassCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.TypeInfo.TypeName}_Builders.generated.cs",
			TemplateProcessor.MockedTypeBuilderClassesCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.TypeInfo.TypeName}_Fake.generated.cs",
			TemplateProcessor.MockedTypeClassCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.TypeInfo.TypeName}_Expect.generated.cs",
			TemplateProcessor.MockedTypeExpectClassesCode,
			dependencySpecification);

		files.AddFile(
			$"{mockSpecification.TypeName}.generated.cs",
			TemplateProcessor.GenerateMockCode,
			mockSpecification);

		return files;
	}

	private SourceFilesToCreate GenerateDependencyCode(DependencySpecification dependencySpecification)
	{
		return dependencySpecification.IsMockable
			? GenerateAbstractDependencyCode(dependencySpecification)
			: GenerateConcreteDependencyCode(dependencySpecification);
	}

	private SourceFilesToCreate GenerateConcreteDependencyCode(
		DependencySpecification dependencySpecification)
	{
		SourceFilesToCreate files = new ();

		files.AddFile(
			$"{dependencySpecification.DependencyType.TypeName}_IsOnly_Builder.generated.cs",
			TemplateProcessor.DependencyStaticBuilderCode,
			dependencySpecification);

		return files;
	}

	private SourceFilesToCreate GenerateAbstractDependencyCode(
		DependencySpecification dependencySpecification)
	{
		SourceFilesToCreate files = new ();

		files.AddFile(
			$"{dependencySpecification.MockedTypeMethodsTypeName}.generated.cs",
			TemplateProcessor.MockedTypeMethodsClassCode,
			dependencySpecification.MockedType!);

		// TODO some code seems repeated in MockedTypeBuilderClassesCode and DependencyStaticBuilderCode
		files.AddFile(
			$"{dependencySpecification.DependencyType.TypeName}_Builders.generated.cs",
			TemplateProcessor.MockedTypeBuilderClassesCode,
			dependencySpecification.MockedType!);

		// TODO some code seems repeated in MockedTypeBuilderClassesCode and DependencyStaticBuilderCode
		files.AddFile(
			$"{dependencySpecification.DependencyType.TypeName}_NamedInstanceBuilder.generated.cs",
			TemplateProcessor.DependencyStaticBuilderCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.DependencyType.TypeName}_Fake.generated.cs",
			TemplateProcessor.MockedTypeClassCode,
			dependencySpecification.MockedType!);

		files.AddFile(
			$"{dependencySpecification.DependencyType.TypeName}_Expect.generated.cs",
			TemplateProcessor.MockedTypeExpectClassesCode,
			dependencySpecification.MockedType!);

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

internal class SourceFileComparer : IEqualityComparer<SourceFileToGenerate>
{
	public bool Equals(SourceFileToGenerate x, SourceFileToGenerate y)
	{
		if (ReferenceEquals(x, y))
			return true;

		if (x is null || y is null)
			return false;

		return x.FileName == y.FileName;
	}

	public int GetHashCode(SourceFileToGenerate obj)
	{
		return obj.FileName.GetHashCode();
	}
}
