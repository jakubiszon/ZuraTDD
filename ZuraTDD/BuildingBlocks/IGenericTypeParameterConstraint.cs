using System;

namespace ZuraTDD.BuildingBlocks;

/// <summary>
/// Defines a constraint for a generic type parameter of a method or class.
/// </summary>
public interface IGenericTypeParameterConstraint
{
	bool IsMatching(Type type);
}
