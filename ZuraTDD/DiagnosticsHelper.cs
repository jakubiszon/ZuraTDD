using Microsoft.CodeAnalysis;

namespace ZuraTDD;

internal static class DiagnosticsHelper
{
	// TODO: this one is not used anymore
	public static Diagnostic ZuraTest_IncorrectTypeArgument(
		ITypeSymbol typeArgument,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA001",
				title: "ZuraTest generic type must implement ITestCase<T>",
				messageFormat: "Type '{0}' used with ZuraTest must implement ITestCase<T>",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			typeArgument.ToDisplayString());
	}

	public static Diagnostic ZuraTest_IncorrectReturnType(
		IMethodSymbol methodSymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA002",
				title: "ZuraTest decorated method must return IEnumerable<ITestPart> or ITestPart[]",
				messageFormat: "Method '{0}' decorated with ZuraTest must return IEnumerable<ITestPart> or ITestPart[]",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			methodSymbol.Name);
	}

	public static Diagnostic ZuraTest_IncorrectReturnType(
		IPropertySymbol propertySymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA003",
				title: "ZuraTest decorated property must return IEnumerable<ITestPart> or ITestPart[]",
				messageFormat: "Property '{0}' decorated with ZuraTest must return IEnumerable<ITestPart> or ITestPart[]",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			propertySymbol.Name);
	}

	public static Diagnostic ZuraTest_MethodHasParameters(
		IMethodSymbol methodSymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA004",
				title: "ZuraTest decorated method must take no parameters",
				messageFormat: "Method '{0}' decorated with ZuraTest must take no parameters",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			methodSymbol.Name);
	}

	public static Diagnostic ZuraTest_MethodHasParameters(
		IPropertySymbol propertySymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA005",
				title: "ZuraTest decorated property must not be an indexer",
				messageFormat: "Property '{0}' decorated with ZuraTest must not be an indexer",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			propertySymbol.Name);
	}

	public static Diagnostic ZuraTest_MustBeInZuraTestClass(
		IMethodSymbol methodSymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA006",
				title: "ZuraTest decorated method must be inside a class decorated with [ZuraTestClass<T>]",
				messageFormat: "Method '{0}' decorated with [ZuraTest] must be inside a class decorated with [ZuraTestClass<T>]",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			methodSymbol.Name);
	}

	public static Diagnostic ZuraTest_MustBeInZuraTestClass(
		IPropertySymbol propertySymbol,
		Location? location)
	{
		return Diagnostic.Create(
			new DiagnosticDescriptor(
				id: "ZURA006",
				title: "ZuraTest decorated property must be inside a class decorated with [ZuraTestClass<T>]",
				messageFormat: "Property '{0}' decorated with [ZuraTest] must be inside a class decorated with [ZuraTestClass<T>]",
				category: "ZuraTDD.TestGenerator",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true),
			location,
			propertySymbol.Name);
	}
}
