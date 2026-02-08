using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a method specification used in code generation.
/// The method belongs either to an object marked as a TestCase
/// or to one of the generated fake services.
/// </summary>
internal class MethodSpecification
{
	private static readonly SymbolDisplayFormat TypeOfFormat =
		new(
			typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
			genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
			miscellaneousOptions: SymbolDisplayMiscellaneousOptions.None
		);

	public string MethodName { get; }

	public MethodType MethodType { get; }

	public string ReturnType { get; }

	/// <summary>
	/// Token used to define and refer to this methods cached MethodInfo instance.
	/// </summary>
	public string Token { get; }

	public List<ParameterSpecification> Parameters { get; }

	/// <summary>
	/// Type which this method returns inside the Task{T} or ValueTask{T}.
	/// This only applies when MethodType is TaskOfT or ValueTaskOfT.
	/// </summary>
	public string AwaitedType { get; }

	public MethodSpecification(
		IMethodSymbol methodSymbol,
		bool hasOverloads)
	{
		MethodName = methodSymbol.Name;
		ReturnType = methodSymbol.ReturnType.ToDisplayString();
		Parameters = methodSymbol
			.Parameters
			.Select(p => new ParameterSpecification
			{
				Type = p.Type.ToDisplayString(),
				Name = p.Name,
				TypeofType = p.Type.ToDisplayString(TypeOfFormat),
			})
			.ToList();
		Token = GenerateMethodToken(MethodName, hasOverloads, Parameters);

		var (methodType, awaitedType) = DetermineMethodType(methodSymbol);
		MethodType = methodType;
		AwaitedType = awaitedType;
	}

	private static string GenerateMethodToken(
		string methodName,
		bool hasOverloads,
		List<ParameterSpecification> parameters)
	{
		if (!hasOverloads)
			return methodName;

		return parameters.Any()
			? $"{methodName}__by__{GetParametersSuffix(parameters)}"
			: methodName;
	}

	private static string GetParametersSuffix(List<ParameterSpecification> parameters)
	{
		return string.Join("_", parameters.Select(p =>
		{
			var shortTypeName = p.Type.Split('.').Last();

			// Remove generic brackets and replace with underscores
			return shortTypeName
				.Replace("<", "_")
				.Replace(">", "_")
				.Replace(",", "_")
				.Replace(" ", "")
				.TrimEnd('_');
		}));
	}

	private static (MethodType, string) DetermineMethodType(IMethodSymbol methodSymbol)
	{
		var namedType = methodSymbol.ReturnType as INamedTypeSymbol;
		return methodSymbol switch
		{
			{ ReturnType.SpecialType: SpecialType.System_Void } => (MethodType.Void, string.Empty),

			{ ReturnType.Name: "Task" } => namedType! switch
			{
				{ IsGenericType: true } => (MethodType.TaskOfT, GetAwaitedType(methodSymbol)),
				_ => (MethodType.Task, string.Empty),
			},

			{ ReturnType.Name: "ValueTask" } => namedType! switch
			{
				{ IsGenericType: true } => (MethodType.ValueTaskOfT, GetAwaitedType(methodSymbol)),
				_ => (MethodType.ValueTask, string.Empty),
			},

			_ => (MethodType.Value, string.Empty),
		};
	}

	private static string GetAwaitedType(IMethodSymbol methodSymbol)
	{
		if (methodSymbol.ReturnType is INamedTypeSymbol namedType &&
			namedType.IsGenericType &&
			namedType.TypeArguments.Length == 1)
		{
			return namedType.TypeArguments[0].ToDisplayString();
		}

		return string.Empty;
	}
}
