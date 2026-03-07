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
		var validatedMethodsProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: IsMethod,
				transform: AsMethodSymbol)
			.Where(methodSymbol => methodSymbol != null)
			.Combine(context.CompilationProvider)
			.Select((pair, _) => ValidateSourceMethod(pair.Left!, pair.Right));

		var validatedPropertiesProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: IsProperty,
				transform: AsPropertySymbol)
			.Where(propertySymbol => propertySymbol != null)
			.Combine(context.CompilationProvider)
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
	private static ZuraTestAnalysis ValidateSourceMethod(IMethodSymbol methodSymbol, Compilation compilation)
	{
		var methodSyntaxRef = methodSymbol.DeclaringSyntaxReferences.FirstOrDefault();

		if (methodSyntaxRef == null)
			return new ZuraTestAnalysis();

		var methodSyntax = methodSyntaxRef.GetSyntax() as MethodDeclarationSyntax;

		var zuraTestAttr = methodSymbol.GetAttributes()
			.FirstOrDefault(attr =>
				attr.AttributeClass?.ContainingNamespace.ToDisplayString() == nameof(ZuraTDD) &&
				attr.AttributeClass.Name == nameof(ZuraTest<>));

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
			var iTestCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");

			if (!ImplementsInterface(typeArgument, iTestCaseInterface))
			{
				var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectTypeArgument(typeArgument, location);
				return new ZuraTestAnalysis(diagnosticMessage);
			}
		}

		// Check if method returns IEnumerable<ITestPart> or ITestPart[]
		var returnType = methodSymbol.ReturnType;
		var isValidReturnType = IsValidTestPartReturnType(returnType, compilation);
		if (!isValidReturnType)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectReturnType(methodSymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		var testSpecification = new TestSpecification(methodSymbol, zuraTestAttr);
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
	private static ZuraTestAnalysis ValidateSourceProperty(IPropertySymbol propertySymbol, Compilation compilation)
	{
		var propertySyntaxRef = propertySymbol.DeclaringSyntaxReferences.FirstOrDefault();

		if (propertySyntaxRef == null)
			return new ZuraTestAnalysis();

		var propertySyntax = propertySyntaxRef.GetSyntax() as MethodDeclarationSyntax;

		var zuraTestAttr = propertySymbol.GetAttributes()
			.FirstOrDefault(attr =>
				attr.AttributeClass?.ContainingNamespace.ToDisplayString() == nameof(ZuraTDD) &&
				attr.AttributeClass.Name == nameof(ZuraTest<>));

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
			var iTestCaseInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestCase`1");

			if (!ImplementsInterface(typeArgument, iTestCaseInterface))
			{
				var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectTypeArgument(typeArgument, location);
				return new ZuraTestAnalysis(diagnosticMessage);
			}
		}

		// Check if property returns IEnumerable<ITestPart> or ITestPart[]
		var returnType = propertySymbol.Type;
		var isValidReturnType = IsValidTestPartReturnType(returnType, compilation);
		if (!isValidReturnType)
		{
			var diagnosticMessage = DiagnosticsHelper.ZuraTest_IncorrectReturnType(propertySymbol, location);
			return new ZuraTestAnalysis(diagnosticMessage);
		}

		var testSpecification = new TestSpecification(propertySymbol, zuraTestAttr);
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

	private static bool IsValidTestPartReturnType(ITypeSymbol returnType, Compilation compilation)
	{
		var iTestPartInterface = compilation.GetTypeByMetadataName("ZuraTDD.ITestPart");

		// Check for ITestPart[]
		if (returnType is IArrayTypeSymbol arrayType)
		{
			return SymbolEqualityComparer.Default.Equals(
				arrayType.ElementType,
				iTestPartInterface);
		}

		// Check for IEnumerable<ITestPart>
		if (returnType is INamedTypeSymbol namedType)
		{
			var enumerableInterface = compilation.GetTypeByMetadataName("System.Collections.Generic.IEnumerable`1");

			if (enumerableInterface != null &&
				SymbolEqualityComparer.Default.Equals(
					namedType.OriginalDefinition,
					enumerableInterface))
			{
				if (namedType.TypeArguments.Length > 0)
				{
					return SymbolEqualityComparer.Default.Equals(
						namedType.TypeArguments[0],
						iTestPartInterface);
				}
			}
		}

		return false;
	}
}
