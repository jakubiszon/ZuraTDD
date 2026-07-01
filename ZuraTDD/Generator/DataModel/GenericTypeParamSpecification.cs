using System;
using System.Collections.Generic;
using System.Text;
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
