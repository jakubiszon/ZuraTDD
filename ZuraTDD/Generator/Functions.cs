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

	public static List<MethodSpecification> ExtractPublicMethods(INamedTypeSymbol? typeSymbol)
	{
		if (typeSymbol == null) return [];

		var allPublicMethods = typeSymbol
			.GetMembers()
			.OfType<IMethodSymbol>()
			.Where(m => m.DeclaredAccessibility == Accessibility.Public && !m.IsStatic)
			.Where(m => m.Name != ".ctor")
			.ToList();

		return allPublicMethods
			.Select(method =>
			{
				var methodsWithSameName = allPublicMethods.Count(m => m.Name == method.Name);
				var hasOverloads = methodsWithSameName > 1;
				return new MethodSpecification(method, hasOverloads);
			})
			.ToList();
	}

	public static string PrependNotEmpty(this string? input, string prepend)
	{
		return string.IsNullOrEmpty(input)
			? ""
			: prepend + input;
	}
}
