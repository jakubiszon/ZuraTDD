using System;
using System.Collections.Generic;
using System.Text;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

// not sure if thi class is needed,
// I might rather specify this as
// Expect.Dependency
//     .GenericMethod<ANY_TYPE, INHERITED_FROM<ANOTHER_TYPE>>(
//     parameterValueConstraint...)
public static class GenericTypeParameters
{
	/// <summary>
	/// Represents a generic type parameter constraint that matches any type.
	/// </summary>
	public static IGenericTypeParameterConstraint Any() => new GenericTypeParameterConstraint(t => true);

	public static IGenericTypeParameterConstraint Inherits<TBase>() where TBase : class
	{
		return new GenericTypeParameterConstraint(t => typeof(TBase).IsAssignableFrom(t));
	}
}
