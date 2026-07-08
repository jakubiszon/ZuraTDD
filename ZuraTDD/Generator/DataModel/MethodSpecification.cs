using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a method specification used in code generation.
/// The method belongs either to an object marked as a TestCase
/// or to one of the generated mock-object-classes.
/// </summary>
internal class MethodSpecification : IUseGenericTypeParameters
{
	public string MethodName { get; }

	/// <summary>
	/// Determines if and how does the method return its return value.
	/// </summary>
	public MethodType MethodType { get; }

	/// <summary>
	/// Name the type returned as the method result.
	/// </summary>
	public string ReturnType { get; }

	/// <summary>
	/// Token used to define and refer to this method's cached ZuraMethodInfo instance.
	/// </summary>
	public string MethodCodeName { get; }

	/// <summary>
	/// A token used to distinguish methods
	/// </summary>
	public string MethodUniqueToken { get; }

	/// <summary>
	/// A token shown to the user to describe the method.
	/// </summary>
	/// <remarks>
	/// The difference between <see cref="MethodUniqueToken"/> and <see cref="MethodDisplayToken"/>
	/// is that the latter includes names of the generic type parameters.
	/// These names could make the token look different while the methods might still be considered identical.
	/// e.g. void Foo&lt;T&gt;(T) and void Foo&lt;U&gt;(U) are identical methods but their display tokens would be different.
	/// </remarks>
	public string MethodDisplayToken { get; }

	public IReadOnlyCollection<GenericTypeParamSpecification> GenericTypeParameters { get; }

	/// <summary>
	/// Defines the parameters of the method.
	/// </summary>
	public List<ParameterSpecification> Parameters { get; }

	/// <summary>
	/// Type which this method returns inside the Task{T} or ValueTask{T}.
	/// This only applies when <see cref="MethodSpecification.MethodType">MethodType</see> is
	/// either <see cref="DataModel.MethodType.TaskOfT">TaskOfT</see>
	/// or <see cref="DataModel.MethodType.ValueTaskOfT">ValueTaskOfT</see>.
	/// </summary>
	public string AwaitedType { get; }

	/// <summary>
	/// The type which defines the method. It can be an interface other than the class where the method is seen.
	/// </summary>
	public TypeInfo DefiningType { get; }

	/// <param name="definingType">The type which defines the method. It can be an interface other than the class where the method is seen.</param>
	/// <param name="methodSymbol">The symbol representing the method.</param>
	/// <param name="hasOverloads">Indicates whether the method has overloads.</param>
	public MethodSpecification(
		INamedTypeSymbol definingType,
		IMethodSymbol methodSymbol,
		bool hasOverloads)
	{
		MethodName = methodSymbol.Name;
		ReturnType = methodSymbol.ReturnType.ToDisplayString();
		DefiningType = new TypeInfo(definingType);

		Parameters = methodSymbol
			.Parameters
			.Select(p => new ParameterSpecification(p))
			.ToList();

		GenericTypeParameters = methodSymbol
			.TypeParameters
			.Select(tp => new GenericTypeParamSpecification(tp))
			.ToList();

		MethodCodeName = GenerateMethodToken(
			MethodName,
			hasOverloads,
			Parameters,
			GenericTypeParameters);

		MethodUniqueToken = GenerateUniqueToken(methodSymbol, GenericTypeParameters);
		MethodDisplayToken = GenerateDisplayToken(methodSymbol, GenericTypeParameters);

		var (methodType, awaitedType) = DetermineMethodType(methodSymbol);
		MethodType = methodType;
		AwaitedType = awaitedType;
	}

	private static string GenerateUniqueToken(
		IMethodSymbol methodSymbol,
		IReadOnlyCollection<GenericTypeParamSpecification> genericTypeParameters)
	{
        var returnType = methodSymbol.ReturnType.ToDisplayString();
        var methodName = methodSymbol.Name;
        var genericArity = methodSymbol.TypeParameters.Length > 0 
            ? $"`{methodSymbol.TypeParameters.Length}" 
            : "";
        
        var parameters = string.Join(", ", 
            methodSymbol.Parameters.Select(p => p.Type.ToDisplayString()));
        
		var whereClauses = genericTypeParameters
			.Where(gtp => gtp.Where.Length > 0)
			.Select(gtp => gtp.Where);

		var whereClausesSuffix = whereClauses.Any()
			? $" {string.Join(" ", whereClauses)}"
			: "";

        return $"{returnType} {methodName}{genericArity}({parameters}){whereClausesSuffix}";
	}

	private static string GenerateDisplayToken(
		IMethodSymbol methodSymbol,
		IReadOnlyCollection<GenericTypeParamSpecification> genericTypeParameters)
	{
        var returnType = methodSymbol.ReturnType.ToDisplayString();
        var methodName = methodSymbol.Name;

        var typeParams = methodSymbol.TypeParameters.Length > 0
            ? $"<{string.Join(", ", methodSymbol.TypeParameters.Select(tp => tp.ToDisplayString()))}>"
            : "";

		var whereClauses = genericTypeParameters
			.Where(gtp => gtp.Where.Length > 0)
			.Select(gtp => gtp.Where);

		var whereClausesSuffix = whereClauses.Any()
			? $" {string.Join(" ", whereClauses)}"
			: "";

		var parameters = string.Join(", ", 
            methodSymbol.Parameters.Select(p => p.Type.ToDisplayString()));
        
        return $"{returnType} {methodName}{typeParams}({parameters}){whereClausesSuffix}";
	}

	private static string GenerateMethodToken(
		string methodName,
		bool hasOverloads,
		List<ParameterSpecification> parameters,
		IReadOnlyCollection<GenericTypeParamSpecification> genericTypeParameters)
	{
		if (!hasOverloads)
			return methodName;

		var genericParamNamesSuffix = genericTypeParameters.Count > 0
			? $"__{string.Join("_", genericTypeParameters.Select(gp => gp.Name))}"
			: "";

		var byParmsSuffix = parameters.Count > 0
			? $"__by_{GetParametersSuffix(parameters)}"
			: "";

		var whereClauses = genericTypeParameters
			.Select(gtp => gtp.Where)
			.Where(whereClause => whereClause.Length > 0)
			.Select(WhereSuffixPart);

		var whereClausesSuffix = whereClauses.Any()
			? string.Join("", whereClauses)
			: "";

		return $"{methodName}{genericParamNamesSuffix}{byParmsSuffix}{whereClausesSuffix}";
	}

	private static string WhereSuffixPart(string whereClause)
	{
		var simplifiedWhereClause = whereClause
			.Replace("where ", "__where_")
			.Replace(" ", "")
			.Replace("global::", "global_")
			.Replace(":", "_")
			.Replace(".", "_")
			.Replace("new()", "new");

		return Tokenize(simplifiedWhereClause);
	}

	private static string GetParametersSuffix(List<ParameterSpecification> parameters)
	{
		return string.Join("_", parameters.Select(p =>
		{
			var shortTypeName = p.Type.Split('.').Last();

			// Remove generic brackets and replace with underscores
			return Tokenize(shortTypeName);
		}));
	}

	private static string Tokenize(string typeOrSomething)
	{
		return typeOrSomething
			.Replace("<", "_")
			.Replace(">", "_")
			.Replace(",", "_")
			.Replace(" ", "")
			.TrimEnd('_');
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
