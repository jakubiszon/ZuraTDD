using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class GenericTypeParamSpecification
{
	public string Name { get; }

	public GenericTypeParamSpecification(ITypeParameterSymbol typeParameterSymbol)
	{
		Name = typeParameterSymbol.Name;
	}
}
