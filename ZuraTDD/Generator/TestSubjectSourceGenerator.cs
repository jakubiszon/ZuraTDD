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

		//var diagnostics = filesProvider
		//	.Where(fileOrDiagnostic => fileOrDiagnostic.Diagnostic != null)

		context.RegisterSourceOutput(
			filesProvider,
			(context, collected) =>
			{
				foreach (var group in collected.GroupBy(file => file.SourceFile!.FileName))
				{
					var file = group.First();
					context.AddSource(file.SourceFile!.FileName, file.SourceFile!.GeneratorFunction());
				}
			});
	}

	/// <summary>
	/// Returns true if the specified pair represents one of:
	/// <list type="bullet">
	/// <item>a class that implements ITestCase&lt;T&gt; interface</item>
	/// <item>a class that implements IMock&lt;T&gt; interface</item>
	/// <item>a class decorated with [ZuraTestClass&lt;TSubject&gt;]</item>
	/// </list>
	/// </summary>
	private bool PairRequiresCodeGeneration((ClassDeclarationSyntax, Compilation) pair)
	{
		var (classDecl, compilation) = pair;
		var testCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
		var mockInterface = compilation.GetTypeByMetadataName("ZuraTDD.IMock`1");
		var zuraTestClassAttribute = compilation.GetTypeByMetadataName("ZuraTDD.ZuraTestClass`1");

		var model = compilation.GetSemanticModel(classDecl.SyntaxTree);
		var typeSymbol = model.GetDeclaredSymbol(classDecl) as INamedTypeSymbol;

		if (typeSymbol == null)
			return false;

		bool isTestCase = testCaseInterface != null
			&& typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, testCaseInterface));

		bool isMock = mockInterface != null
			&& typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, mockInterface));

		bool isZuraTestClass = zuraTestClassAttribute != null
			&& typeSymbol.GetAttributes().Any(attr => IsSameAttribute(attr.AttributeClass!, zuraTestClassAttribute));

		return isTestCase || isMock || isZuraTestClass;
	}

	private bool IsSameInterface(INamedTypeSymbol interface1, INamedTypeSymbol? interface2)
	{
		if(interface2 == null)
			return false;

		return SymbolEqualityComparer
			.Default
			.Equals(interface1.OriginalDefinition, interface2);
	}

	private bool IsSameAttribute(INamedTypeSymbol attribute1, INamedTypeSymbol? attribute2)
	{
		if (attribute2 == null)
			return false;
		return SymbolEqualityComparer
			.Default
			.Equals(attribute1.OriginalDefinition, attribute2);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pair"></param>
	/// <returns></returns>
	private ImmutableArray<SourceFileOrDiagnostic> ProcessCandidateClass(
		(ClassDeclarationSyntax, Compilation) pair)
	{
		var (candidate, compilation) = pair;

		var model = compilation.GetSemanticModel(candidate.SyntaxTree);
		var typeSymbol = model.GetDeclaredSymbol(candidate) as INamedTypeSymbol;

		if (typeSymbol == null)
			return ImmutableArray<SourceFileOrDiagnostic>.Empty;

		// Get interfaces
		var testCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
		var mockInterface = compilation.GetTypeByMetadataName("ZuraTDD.IMock`1");
		var zuraTestClassAttribute = compilation.GetTypeByMetadataName("ZuraTDD.ZuraTestClass`1");

		bool isTestCase = testCaseInterface != null
			&& typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, testCaseInterface));

		bool isMock = mockInterface != null
			&& typeSymbol.AllInterfaces.Any(@interface => IsSameInterface(@interface, mockInterface));

		bool isZuraTestClass = zuraTestClassAttribute != null
			&& typeSymbol.GetAttributes().Any(attr => IsSameAttribute(attr.AttributeClass!, zuraTestClassAttribute));

		var isPartial = candidate.Modifiers.Any(token => token.ValueText == "partial");

		if (isTestCase && isMock) // TODO: or isZuraTestClass combined with either of the other two
		{
			// TODO restore diagnostics
			//OutputMultipleGeneratorsNotAllowedDiagnostic(context, candidate, typeSymbol);
			return ImmutableArray<SourceFileOrDiagnostic>.Empty;
		}

		if(!isPartial)
		{
			// TODO restore diagnostics
			//string interfaceName = isTestCase ? "ITestCase<T>" : "IMock<T>";
			//OutputSymbolNotPartialDiagnostic(context, candidate, typeSymbol, interfaceName);
			return ImmutableArray<SourceFileOrDiagnostic>.Empty;
		}

		if (isTestCase)
		{
			return GenerateTestCaseCode(typeSymbol)
				.GetItems()
				.ToImmutableArray();
		}
		else if (isMock)
		{
			return GenerateMockCode(typeSymbol)
				.GetItems()
				.ToImmutableArray();
		}
		else if (isZuraTestClass)
		{
			return GenerateZuraTestClassCode(typeSymbol, zuraTestClassAttribute!)
				.GetItems()
				.ToImmutableArray();
		}
		else
		{
			return ImmutableArray<SourceFileOrDiagnostic>.Empty;
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
			testCaseSpecification.TestSubject.DependenciesClass.OutputFileName,
			TemplateProcessor.PrepareTestSubjectDependenciesClassCode,
			testCaseSpecification.TestSubject.DependenciesClass);

		foreach (var dependency in testCaseSpecification.TestSubject.DependenciesClass.Dependencies)
		{
			var dependencyFilesToAdd = GenerateDependencyCode(dependency);
			files.AddFiles(dependencyFilesToAdd.GetItems());
		}

		return files;
	}

	/// <summary>
	/// Emits a <see langword="partial" /> class containing the Receives/When/Expect static builders
	/// needed for a class declared as <see cref="ZuraTestClass{TSubject}"/>.
	/// Also generates an implicit TestCase class for the subject type
	/// </summary>
	/// <param name="typeSymbol"></param>
	/// <param name="zuraTestClassAttribute"></param>
	/// <returns></returns>
	private SourceFilesToCreate GenerateZuraTestClassCode(
		INamedTypeSymbol typeSymbol,
		INamedTypeSymbol zuraTestClassAttribute)
	{
		var attributeData = typeSymbol.GetAttributes()
			.FirstOrDefault(attr =>
				attr.AttributeClass != null
				&& SymbolEqualityComparer.Default.Equals(
					attr.AttributeClass.OriginalDefinition,
					zuraTestClassAttribute));

		if (attributeData == null || attributeData.AttributeClass == null)
			return new SourceFilesToCreate();

		var subjectType = attributeData.AttributeClass.TypeArguments[0] as INamedTypeSymbol;
		if (subjectType == null)
			return new SourceFilesToCreate();

		SourceFilesToCreate files = new ();
		var spec = new ZuraTestClassSpecification(typeSymbol, subjectType);

		files.AddFile(
			$"{spec.DecoratedClassNamespace}.{typeSymbol.Name}.ZuraTestClass.generated.cs",
			TemplateProcessor.PrepareZuraTestClassCode,
			spec);

		files.AddFile(
			spec.ImplicitTestCaseClass.OutputFileName,
			TemplateProcessor.PrepareImplicitTestCaseClassCode,
			spec);

		files.AddFile(
			spec.TestSubject.DependenciesClass.OutputFileName,
			TemplateProcessor.PrepareTestSubjectDependenciesClassCode,
			spec.TestSubject.DependenciesClass);

		foreach (var dependency in spec.TestSubject.DependenciesClass.Dependencies)
		{
			var filesToAdd = GenerateDependencyCode(dependency);
			files.AddFiles(filesToAdd.GetItems());
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
			$"{dependencySpecification.OutputFilePrefix}_Methods.generated.cs",
			TemplateProcessor.MockedTypeMethodsClassCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Builder.generated.cs",
			TemplateProcessor.MockedTypeBuilderClassesCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Fake.generated.cs",
			TemplateProcessor.MockedTypeClassCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Expect.generated.cs",
			TemplateProcessor.MockedTypeExpectClassesCode,
			dependencySpecification);

		files.AddFile(
			$"{mockSpecification.OutputNamespace}.{mockSpecification.TypeName}.generated.cs",
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
			$"{dependencySpecification.OutputFilePrefix}_NamedInstanceBuilder.generated.cs",
			TemplateProcessor.DependencyStaticBuilderCode,
			dependencySpecification);

		return files;
	}

	private SourceFilesToCreate GenerateAbstractDependencyCode(
		DependencySpecification dependencySpecification)
	{
		SourceFilesToCreate files = new ();

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Methods.generated.cs",
			TemplateProcessor.MockedTypeMethodsClassCode,
			dependencySpecification.MockedType!);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Builder.generated.cs",
			TemplateProcessor.MockedTypeBuilderClassesCode,
			dependencySpecification.MockedType!);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_NamedInstanceBuilder.generated.cs",
			TemplateProcessor.DependencyStaticBuilderCode,
			dependencySpecification);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Fake.generated.cs",
			TemplateProcessor.MockedTypeClassCode,
			dependencySpecification.MockedType!);

		files.AddFile(
			$"{dependencySpecification.OutputFilePrefix}_Expect.generated.cs",
			TemplateProcessor.MockedTypeExpectClassesCode,
			dependencySpecification.MockedType!);

		return files;
	}

	private Diagnostic OutputSymbolNotPartialDiagnostic(
		SourceProductionContext context,
		ClassDeclarationSyntax candidate,
		INamedTypeSymbol candidateTypeSymbol,
		string interfaceName)
	{
		var location = candidate.GetLocation();
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "SG0001",
				title: $"A class implementing {interfaceName} must be partial.",
				messageFormat: $"Type '{{0}}' implements {interfaceName} and must be declared as 'partial'.",
				category: "ZuraTDD",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true),
			location,
			candidateTypeSymbol.Name);
	}

	private Diagnostic OutputMultipleGeneratorsNotAllowedDiagnostic(
		SourceProductionContext context,
		ClassDeclarationSyntax candidate,
		INamedTypeSymbol candidateTypeSymbol)
	{
		var location = candidate.GetLocation();
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "SG0003",
				title: "A class cannot implement ITestCase<T> and IMock<T> at the same time.",
				messageFormat: "Type '{0}' is implementing ITestCase<T> and IMock<T> which is not allowed.",
				category: "ZuraTDD",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true),
			location,
			candidateTypeSymbol.Name);
	}
}

internal class SourceFileComparer : IEqualityComparer<SourceFileOrDiagnostic>
{
	public bool Equals(SourceFileOrDiagnostic x, SourceFileOrDiagnostic y)
	{
		if (ReferenceEquals(x, y))
			return true;

		if (x is null || y is null)
			return false;

		if (x.Diagnostic != null || y.Diagnostic != null)
			return false;

		return x.SourceFile!.FileName == y.SourceFile!.FileName;
	}

	public int GetHashCode(SourceFileOrDiagnostic obj)
	{
		return obj.SourceFile?.FileName.GetHashCode()
			?? obj.Diagnostic?.GetHashCode()
			?? 0;
	}
}
