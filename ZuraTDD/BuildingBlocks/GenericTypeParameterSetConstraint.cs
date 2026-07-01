using System;

namespace ZuraTDD.BuildingBlocks;

/// <summary>
/// An object that tests specific type parameters used in actual method calls against a set of constraints.
/// </summary>
public class GenericTypeParameterSetConstraint
{
	private readonly IGenericTypeParameterConstraint[] constraints;

	public GenericTypeParameterSetConstraint(params IGenericTypeParameterConstraint[] constraints)
	{
		this.constraints = constraints;
	}

	/// <summary>
	/// Returns <see langword="true" /> if the specified generic arguments match the constraints.
	/// </summary>
	/// <param name="genericArguments">The generic arguments to test against the constraints.</param>
	public bool Matches(Type[]? genericArguments)
	{
		if (genericArguments == null)
		{
			return constraints.Length == 0;
		}

		if (genericArguments.Length != constraints.Length)
		{
			return false;
		}

		for (int i = 0; i < genericArguments.Length; i++)
		{
			if (!constraints[i].IsMatching(genericArguments[i]))
			{
				return false;
			}
		}

		return true;
	}
}
