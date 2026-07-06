using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class GenericTypeParamSpecification
{
	public string Name { get; }

	public string Where { get; }

	public GenericTypeParamSpecification(ITypeParameterSymbol typeParameterSymbol)
	{
		Name = typeParameterSymbol.Name;

		var constraints = ListConstraints(typeParameterSymbol)
			.ToList();

		Where = constraints.Count > 0
			? $"where {Name} : {string.Join(", ", constraints)}"
			: string.Empty;
	}

	private static IEnumerable<string> ListConstraints(ITypeParameterSymbol typeParameterSymbol)
	{
		if(typeParameterSymbol.HasReferenceTypeConstraint)
			yield return "class";

		if(typeParameterSymbol.HasConstructorConstraint)
			yield return "new()";

		if(typeParameterSymbol.HasValueTypeConstraint)
			yield return "struct";

		if(typeParameterSymbol.HasNotNullConstraint)
			yield return "notnull";

		if(typeParameterSymbol.AllowsRefLikeType)
			yield return "allows ref struct";

		if(typeParameterSymbol.HasUnmanagedTypeConstraint)
			yield return "unmanaged";

		if(typeParameterSymbol.ConstraintTypes.Length > 0)
		{
			foreach (var constraintType in typeParameterSymbol.ConstraintTypes)
			{
				yield return constraintType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
			}
		}
	}
}
