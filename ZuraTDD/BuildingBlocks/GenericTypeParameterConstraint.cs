using System;

namespace ZuraTDD.BuildingBlocks;

public class GenericTypeParameterConstraint : IGenericTypeParameterConstraint
{
	private readonly Func<Type, bool> typeConstraint;

	public GenericTypeParameterConstraint(Func<Type, bool> typeConstraint)
	{
		this.typeConstraint = typeConstraint;
	}

	public GenericTypeParameterConstraint(Type type)
	{
		this.typeConstraint = t => t == type;
	}

	public bool IsMatching(Type type)
	{
		return typeConstraint(type);
	}
}
