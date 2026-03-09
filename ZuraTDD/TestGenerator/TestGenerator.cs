using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ZuraTDD.TestGenerator.DataModel;

namespace ZuraTDD.TestGenerator;

/// <summary>
/// Generates implementations for methods decorated with <see cref="ZuraTest{T}" /> attribute.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class TestGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var metadataSource = context.CompilationProvider
			.Select((c, _) => new CompilationMetadata(c));

		var validatedMethodsProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: IsMethod,
				transform: AsMethodSymbol)
			.Where(methodSymbol => methodSymbol != null)
			.Combine(metadataSource)
			.Where(pair => pair.Right.IsValid())
			.Select((pair, _) => ValidateSourceMethod(pair.Left!, pair.Right));

		var validatedPropertiesProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: IsProperty,
				transform: AsPropertySymbol)
			.Where(propertySymbol => propertySymbol != null)
			.Combine(metadataSource)
			.Where(pair => pair.Right.IsValid())
			.Select((pair, _) => ValidateSourceProperty(pair.Left!, pair.Right));

		context.RegisterSourceOutput(
			validatedMethodsProvider,
			EmitCodeAndDiagnostics);

		context.RegisterSourceOutput(
			validatedPropertiesProvider,
			EmitCodeAndDiagnostics);
	}

	private static void EmitCodeAndDiagnostics(SourceProductionContext ctx, ZuraTestAnalysis analysis)
	{
		if (analysis.DiagnosticMessage != null)
		{
			ctx.ReportDiagnostic(analysis.DiagnosticMessage);
		}
		else if (analysis.TestSpecification != null)
		{
			ctx.AddSource(
				analysis.TestSpecification.OutputFileName,
				TestTemplateProcessor.TestMethod(analysis.TestSpecification));
		}
	}

	private static bool IsMethod(SyntaxNode node, CancellationToken _)
	{
		return node is MethodDeclarationSyntax;
	}

	private static bool IsProperty(SyntaxNode node, CancellationToken _)
	{
		return node is PropertyDeclarationSyntax;
	}

	private static IMethodSymbol? AsMethodSymbol(GeneratorSyntaxContext ctx, CancellationToken _)
	{
		var methodSyntax = (MethodDeclarationSyntax)ctx.Node;

		var methodSymbol = ctx.SemanticModel.GetDeclaredSymbol(methodSyntax) as IMethodSymbol;
		if (methodSymbol == null) return null;

		foreach (var attr in methodSymbol.GetAttributes())
		{
			if (attr.AttributeClass?.ContainingNamespace.ToDisplayString() != nameof(ZuraTDD))
				continue;

			if (attr.AttributeClass.Name != nameof(ZuraTest<>))
				continue;

			return methodSymbol;
		}

		return null;
	}

	private static IPropertySymbol? AsPropertySymbol(GeneratorSyntaxContext ctx, CancellationToken _)
	{
		var propertySyntax = (PropertyDeclarationSyntax)ctx.Node;

		var propertySymbol = ctx.SemanticModel.GetDeclaredSymbol(propertySyntax) as IPropertySymbol;
		if (propertySymbol == null) return null;

		foreach (var attr in propertySymbol.GetAttributes())
		{
			if (attr.AttributeClass?.ContainingNamespace.ToDisplayString() != nameof(ZuraTDD))
				continue;

			if (attr.AttributeClass.Name != nameof(ZuraTest<>))
				continue;

			return propertySymbol;
		}

		return null;
	}

	/// <summary>
	/// Verifies that the methodSymbol derotated with <see cref="ZuraTest{T}" /> has the correct structure:
	/// <list type="bullet">
	/// <item>Generic type argument must implement <see cref="ITestCase{T}" /></item>
	/// <item>Method must take no parameters</item>
	/// <item>Method must return <see cref="IEnumerable{ITestPart}" /> or <see cref="ITestPart" />[]</item>
	/// </list>
	/// </summary>
	private static ZuraTestAnalysis ValidateSourceMethod(
		IMethodSymbol methodSymbol,
		CompilationMetadata metadata)
	{
		var methodSyntaxRef = methodSymbol.DeclaringSyntaxReferences.FirstOrDefault();

		if (methodSyntaxRef == null)
			return new ZuraTestAnalysis();

		var methodSyntax = methodSyntaxRef.GetSyntax() as MethodDeclarationSyntax;

		var zuraTestAttr = GetZuraTestAttribute(methodSymbol);
		if (zuraTestAttr == null)
			return new ZuraTestAnalysis();

		var location = methodSyntax?.GetLocation() ?? Location.None;

		// Check if the method has parameters
		if (methodSymbol.Parameters.Length > 0)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_MethodHasParameters(methodSymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		// Check if generic type argument implements ITestCase
		if (zuraTestAttr.AttributeClass?.TypeArguments.Length > 0)
		{
			var typeArgument = zuraTestAttr.AttributeClass.TypeArguments[0];

			if (!ImplementsInterface(typeArgument, metadata.ZuraTDD_ITestCase))
			{
				var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectTypeArgument(typeArgument, location);
				return new ZuraTestAnalysis(diagnosticMessage);
			}
		}

		// Check if method returns IEnumerable<ITestPart> or ITestPart[]
		var returnType = methodSymbol.ReturnType;
		var isValidReturnType = IsValidTestPartReturnType(returnType, metadata);
		if (!isValidReturnType)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectReturnType(methodSymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		var testSpecification = new TestSpecification(
			methodSymbol,
			zuraTestAttr,
			metadata.TestFramework);

		return new ZuraTestAnalysis(testSpecification);
	}

	/// <summary>
	/// Verifies that the propertySymbol derotated with <see cref="ZuraTest{T}" /> has the correct structure:
	/// <list type="bullet">
	/// <item>Generic type argument must implement <see cref="ITestCase{T}" /></item>
	/// <item>Property must not be an indexer</item>
	/// <item>Property must return <see cref="IEnumerable{ITestPart}" /> or <see cref="ITestPart" />[]</item>
	/// </list>
	/// </summary>
	private static ZuraTestAnalysis ValidateSourceProperty(
		IPropertySymbol propertySymbol,
		CompilationMetadata metadata)
	{
		var propertySyntaxRef = propertySymbol.DeclaringSyntaxReferences.FirstOrDefault();

		if (propertySyntaxRef == null)
			return new ZuraTestAnalysis();

		var propertySyntax = propertySyntaxRef.GetSyntax() as MethodDeclarationSyntax;

		var zuraTestAttr = GetZuraTestAttribute(propertySymbol);
		if (zuraTestAttr == null)
			return new ZuraTestAnalysis();

		var location = propertySyntax?.GetLocation() ?? Location.None;

		// Check if the property is an indexer
		if (propertySymbol.Parameters.Length > 0)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_MethodHasParameters(propertySymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		// Check if generic type argument implements ITestCase
		if (zuraTestAttr.AttributeClass?.TypeArguments.Length > 0)
		{
			var typeArgument = zuraTestAttr.AttributeClass.TypeArguments[0];

			if (!ImplementsInterface(typeArgument, metadata.ZuraTDD_ITestCase))
			{
				var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectTypeArgument(typeArgument, location);
				return new ZuraTestAnalysis(diagnosticMessage);
			}
		}

		// Check if property returns IEnumerable<ITestPart> or ITestPart[]
		var returnType = propertySymbol.Type;
		var isValidReturnType = IsValidTestPartReturnType(returnType, metadata);
		if (!isValidReturnType)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectReturnType(propertySymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		var testSpecification = new TestSpecification(
			propertySymbol,
			zuraTestAttr,
			metadata.TestFramework);

		return new ZuraTestAnalysis(testSpecification);
	}

	private static bool ImplementsInterface(ITypeSymbol type, INamedTypeSymbol? interfaceType)
	{
		if (interfaceType == null || type == null)
			return false;

		foreach (var iface in type.AllInterfaces)
		{
			if (SymbolEqualityComparer.Default.Equals(
				iface.OriginalDefinition,
				interfaceType.OriginalDefinition))
			{
				return true;
			}
		}

		return false;
	}

	private static bool IsValidTestPartReturnType(ITypeSymbol returnType, CompilationMetadata metadata)
	{
		// Check for ITestPart[]
		if (returnType is IArrayTypeSymbol arrayType)
		{
			return SymbolEqualityComparer.Default.Equals(
				arrayType.ElementType,
				metadata.ZuraTDD_ITestPart);
		}

		// Check for IEnumerable<ITestPart>
		if (returnType is INamedTypeSymbol namedType)
		{
			if (SymbolEqualityComparer.Default.Equals(
					namedType.OriginalDefinition,
					metadata.System_Collections_Generic_IEnumerable))
			{
				if (namedType.TypeArguments.Length > 0)
				{
					return SymbolEqualityComparer.Default.Equals(
						namedType.TypeArguments[0],
						metadata.ZuraTDD_ITestPart);
				}
			}
		}

		return false;
	}

	private static AttributeData? GetZuraTestAttribute(ISymbol memberSymbol)
	{
		return memberSymbol.GetAttributes()
			.FirstOrDefault(attr =>
				attr.AttributeClass?.ContainingNamespace.ToDisplayString() == nameof(ZuraTDD) &&
				attr.AttributeClass.Name == nameof(ZuraTest<>));
	}

	private class CompilationMetadata
	{
		public INamedTypeSymbol? ZuraTDD_ITestCase { get; }

		public INamedTypeSymbol? ZuraTDD_ITestPart { get; }

		public TestFramework TestFramework { get; }

		public INamedTypeSymbol? System_Collections_Generic_IEnumerable { get; }

		public CompilationMetadata(Compilation compilation)
		{
			ZuraTDD_ITestCase = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");
			ZuraTDD_ITestPart = compilation.GetTypeByMetadataName("ZuraTDD.ITestPart");
			System_Collections_Generic_IEnumerable = compilation.GetTypeByMetadataName("System.Collections.Generic.IEnumerable`1");
			TestFramework = DetectFramework(compilation);
		}

		private TestFramework DetectFramework(Compilation compilation)
		{
			if(compilation.GetTypeByMetadataName("Xunit.FactAttribute") != null)
				return TestFramework.XUnit;

			return TestFramework.MsTest;
		}

		public bool IsValid()
		{
			return ZuraTDD_ITestCase != null
				&& ZuraTDD_ITestPart != null
				&& System_Collections_Generic_IEnumerable != null;
		}
	}
}
