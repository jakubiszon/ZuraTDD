using System;
using System.Collections.Concurrent;

namespace ZuraTDD.BuildingBlocks;

public class GenericTypeParameterConstraint : IGenericTypeParameterConstraint
{
	private static readonly Type typeMatcherInterface = typeof(ITypeMatcher);

	/// <summary>
	/// A dictionary mapping the type of matcher to its single created instance.
	/// </summary>
	private static readonly ConcurrentDictionary<Type, ITypeMatcher> matcherInstances = new();

	private readonly Func<Type, bool> typeConstraint;

	public GenericTypeParameterConstraint(Func<Type, bool> typeConstraint)
	{
		this.typeConstraint = typeConstraint;
	}

	public GenericTypeParameterConstraint(Type type)
	{
		if (typeMatcherInterface.IsAssignableFrom(type))
		{
			var instance = matcherInstances.GetOrAdd(type, t => (ITypeMatcher)Activator.CreateInstance(t)!);
			this.typeConstraint = instance.IsMatching;
		}
		else
		{
			this.typeConstraint = t => t == type;
		}
	}

	public bool IsMatching(Type type)
	{
		return typeConstraint(type);
	}
}
