using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using ZuraTDD.Generator.DataModel;

namespace ZuraTDD.Generator;

internal static class Functions
{
	public static string Capitalize(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}

		return char.ToUpper(input[0]) + input.Substring(1);
	}

	public static bool ImplementsTestCaseInterface(INamedTypeSymbol interfaceTypeSymbol)
	{
		return interfaceTypeSymbol.IsGenericType
			&& interfaceTypeSymbol
				.ConstructUnboundGenericType()
				.ToDisplayString() == "ZuraTDD.ITestCase<>";
	}

	public static bool ImplementsMockInterface(INamedTypeSymbol interfaceTypeSymbol)
	{
		return interfaceTypeSymbol.IsGenericType
			&& interfaceTypeSymbol
				.ConstructUnboundGenericType()
				.ToDisplayString() == "ZuraTDD.IMock<>";
	}

	/// <summary>
	/// Returns a string defining the generic type parameters of the method, formatted as &lt;T1, T2&gt;.
	/// </summary>
	public static string GetMethodGenericTypeParametersString(this MethodSpecification method)
	{
		if (method.GenericTypeParameters.Count == 0)
			return "";

		return $"<{string.Join(", ", method.GenericTypeParameters.Select(p => p.Name))}>";
	}

	/// <summary>
	/// Returns a string which will represent applied generic types inside a generic method implementation.
	/// </summary>
	public static string GetMethodGenericTypeParametersTypeofs(this MethodSpecification method)
	{
		if (method.GenericTypeParameters.Count == 0)
			return "";

		return string.Join(", ", method.GenericTypeParameters.Select(p => $"typeof({p.Name})"));
	}

	/// <summary>
	/// Returns the <see langword="where" /> clases for all generic type parameters of the method.
	/// </summary>
	public static string GetMethodGenericTypeParameterConstraints(this MethodSpecification method, string indentation = "\n\t\t")
	{
		if (method.GenericTypeParameters.All(gtp => gtp.Where.Length == 0))
			return "";

		var paramsWithConstraints = method.GenericTypeParameters
			.Where(gtp => gtp.Where.Length > 0)
			.Select(gtp => gtp.Where);

		return string.Join(indentation, paramsWithConstraints);
	}

	/// <summary>
	/// Returns method parameter types formatted as generic type parameters to be used with generic behavior builders.
	/// The output type parameters include method input types as well as its return type.
	/// </summary>
	public static string GetGenericParamsString(this MethodSpecification method)
	{
		return method switch
		{
			{  ReturnType: not "void", Parameters: { Count: 0 } }
				=> $"<{method.ReturnType}>",

			{ ReturnType: not "void" }
				=> $"<{string.Join(", ", method.Parameters.Select(p => p.Type))}, {method.ReturnType}>",

			{ Parameters: { Count: not 0 } }
				=> $"<{string.Join(", ", method.Parameters.Select(p => p.Type))}>",

			_ => "",
		};
	}

	/// <summary>
	/// Returns method parameter types formatted as generic type parameters to be used with generic asynchronous behavior builders.
	/// The output type parameters include method input types as well as its return type.
	/// </summary>
	public static string GetAsyncMethodGenericParamsString(this MethodSpecification method)
	{
		return method switch
		{
			{ MethodType: MethodType.TaskOfT, Parameters: { Count: 0 } }
				=> $"<{method.AwaitedType}>",

			{ MethodType: MethodType.TaskOfT, Parameters: { Count: > 0 } }
				=> $"<{string.Join(", ", method.Parameters.Select(p => p.Type))}, {method.AwaitedType}>",

			{ MethodType: MethodType.ValueTaskOfT, Parameters: { Count: 0 } }
				=> $"<{method.AwaitedType}>",

			{ MethodType: MethodType.ValueTaskOfT, Parameters: { Count: > 0 } }
				=> $"<{string.Join(", ", method.Parameters.Select(p => p.Type))}, {method.AwaitedType}>",

			_ => throw new NotImplementedException("This method is only implemented for TaskOfT at the moment."),
		};
	}

	public static string GetParamValuesString(this MethodSpecification method)
	{
		if (method.Parameters.Count == 0)
			return "";

		var paramValues = method.Parameters
			.Select(p => p.Name);

		return string.Join(", ", paramValues);
	}

	public static string GetDefaultResult(this MethodSpecification method)
	{
		if (method.MethodType == MethodType.Void)
			return string.Empty;

        return method switch
		{
			{ MethodType: MethodType.Task } => "Task.CompletedTask",
			{ MethodType: MethodType.TaskOfT } => $"Task.FromResult<{method.AwaitedType}>(default({method.AwaitedType})!)",

			{ MethodType: MethodType.ValueTask } => "new ValueTask()",
			{ MethodType: MethodType.ValueTaskOfT } => $"new ValueTask<{method.AwaitedType}>(default({method.AwaitedType})!)",

			{ ReturnType: "char" } => "char.MinValue",
			{ ReturnType: "string" } => "string.Empty",

			_ => "default!",
		};
	}

	/// <summary>
	/// Returns ActionCallSpecification or FuncCallSpecification type-strings
	/// used by the When and Expect test-case subobjects.
	/// </summary>
	public static string PrepareCallSpecificationType(this MethodSpecification methodSpecification)
	{
		return methodSpecification switch
		{
			{ ReturnType: not "void", Parameters: { Count: 0 } }
				=> $"FuncCallSpecification<{methodSpecification.ReturnType}>",

			{ ReturnType: not "void" }
				=> $"FuncCallSpecification<{string.Join(", ", methodSpecification.Parameters.Select(p => p.Type))}, {methodSpecification.ReturnType}>",

			{ Parameters: { Count: not 0 } }
				=> $"ActionCallSpecification<{string.Join(", ", methodSpecification.Parameters.Select(p => p.Type))}>",

			_ => "ActionCallSpecification",
		};
	}

	public static string PrepareReceiveSpecificationType(this MethodSpecification methodSpecification)
	{
		return methodSpecification switch
		{
			{ MethodType: MethodType.Void } => nameof(TestedActionCall),

			{ MethodType: MethodType.Task } => nameof(TestedTaskCall),

			{ MethodType: MethodType.ValueTask } => nameof(TestedValueTaskCall),

			{ MethodType: MethodType.TaskOfT } => $"{nameof(TestedTaskOfTCall<>)}<{methodSpecification.AwaitedType}>",

			{ MethodType: MethodType.ValueTaskOfT } => $"{nameof(TestedValueTaskOfTCall<>)}<{methodSpecification.AwaitedType}>",

			{ MethodType: MethodType.Value } => $"{nameof(TestedFuncCall<>)}<{methodSpecification.ReturnType}>",

			_ => throw new NotImplementedException(),
		};
	}

	/// <summary>
	/// Extracts all public methods defined directly on the specified type.
	/// </summary>
	/// <param name="typeSymbol">Type to extract methods from.</param>
	/// <returns>List of method specifications.</returns>
	public static List<MethodSpecification> ExtractPublicMethods(INamedTypeSymbol? typeSymbol)
	{
		if (typeSymbol == null) return [];

		var allPublicMethods = typeSymbol
			.GetMembers()
			.OfType<IMethodSymbol>()
			.Where(m => !m.IsStatic)
			.Where(m => m.DeclaredAccessibility == Accessibility.Public)
			.Where(m => m.Name != ".ctor")
			.Distinct(SymbolEqualityComparer.Default)
			.Cast<IMethodSymbol>()
			.ToList();

		return allPublicMethods
			.Select(method =>
			{
				var methodsWithSameName = allPublicMethods.Count(m => m.Name == method.Name);
				var hasOverloads = methodsWithSameName > 1;
				return new MethodSpecification(typeSymbol, method, hasOverloads);
			})
			.ToList();
	}

	public static List<MethodSpecification> ExtractInterfaceMethods(INamedTypeSymbol? interfaceSymbol)
	{
		if (interfaceSymbol == null) return [];
		//if (!interfaceSymbol.TypeKind.HasFlag(TypeKind.Interface))
		//	throw new Exception($"The method {nameof(ExtractInterfaceMethods)} received the type '{interfaceSymbol?.Name}' which is not an interface.");

		INamedTypeSymbol[] allInterfaces = [interfaceSymbol, .. interfaceSymbol.AllInterfaces];

		var allPublicMethods = allInterfaces
			.SelectMany(ExtractMethodsWithOwner)
			.ToList();

		return allPublicMethods
			.Select(methodAndType =>
			{
				var methodsWithSameName = allPublicMethods.Count(mt => mt.method.Name == methodAndType.method.Name);
				var hasOverloads = methodsWithSameName > 1;
				return new MethodSpecification(methodAndType.ownerType, methodAndType.method, hasOverloads);
			})
			.DistinctBy(methodSpec => methodSpec.MethodUniqueToken)
			.ToList();
	}

	private static IEnumerable<(INamedTypeSymbol ownerType, IMethodSymbol method)> ExtractMethodsWithOwner(
		INamedTypeSymbol typeSymbol)
	{
		return typeSymbol
			.GetMembers()
			.OfType<IMethodSymbol>()
			.Where(m => !m.IsStatic)
			.Where(m => m.DeclaredAccessibility == Accessibility.Public)
			.Where(HasExpectedMethodKind)
			//.Where(m => m.Name != ".ctor")
			.Distinct(SymbolEqualityComparer.Default)
			.Cast<IMethodSymbol>()
			.Select(method => (ownerType: typeSymbol, method));
	}

	private static bool HasExpectedMethodKind(IMethodSymbol methodSymbol)
	{
		return methodSymbol.MethodKind == MethodKind.Ordinary
			|| methodSymbol.MethodKind == MethodKind.PropertyGet
			|| methodSymbol.MethodKind == MethodKind.PropertySet;
	}

	//public static List<PropertySpecification> ExtractProperties(INamedTypeSymbol? typeSymbol)
	//{
	//	if (typeSymbol == null) return [];

	//	var allProperties = typeSymbol
	//		.GetMembers()
	//		.OfType<IPropertySymbol>()
	//		.Where(p => p.DeclaredAccessibility == Accessibility.Public && !p.IsStatic)
	//		.ToList();

	//	// TODO
	//	return [];
	//}

	public static string PrependNotEmpty(this string input, string prepend)
	{
		return string.IsNullOrEmpty(input)
			? ""
			: prepend + input;
	}
}
