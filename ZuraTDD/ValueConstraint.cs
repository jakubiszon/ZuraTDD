using System;
using System.Linq.Expressions;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// An object defining constraints on a value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Type of value.</typeparam>
public class ValueConstraint<T> : IValueConstraint<T>
{
	// this is a bit of a hack, there will be a separate static field for each T
	// TODO: a possible optimization could be to not initialize this for every type but only for ones which we know could refer generic type matchers
	//       one approach could be to define GenericValueConstraint<T>, move this field there, and use that class in generated code when we know the method is generic
	//       the question is if the use of System.Reflection here is costly enough to justify such change
	private static readonly bool dependsOnTypeMatcher = TypeMatcherHelper.DependsOnTypeMatcher<T>();

	private readonly Expression<Func<T, bool>>? valueConstraint;


	/// <summary>
	/// Builds a constraint accepting any value.
	/// </summary>
	public ValueConstraint()
	{
	}

	/// <summary>
	/// Builds a constraint matching a specific value.
	/// </summary>
	/// <param name="exactValue"></param>
	public ValueConstraint(T exactValue)
	{
		if (exactValue is null)
		{
			this.valueConstraint = x => x == null;
		}
		else
		{
			this.valueConstraint = x => exactValue.Equals(x);
		}
	}

	/// <summary>
	/// Builds a constraint matching a value satisfying the provided condition.
	/// </summary>
	/// <param name="valueConstraint"></param>
	public ValueConstraint(Expression<Func<T, bool>> valueConstraint)
	{
		this.valueConstraint = valueConstraint;
	}

	public bool IsMatching(T value)
	{
		return valueConstraint == null
			|| valueConstraint.Compile().Invoke(value);
	}

	public bool IsMatching<Tin>(Tin value)
	{
		if (dependsOnTypeMatcher)
		{
			// when we match generic method calls against our predefined ITypeMatcher types
			// we do not want to use value constraints on the actual type instance
			// the types used in method invocations will never match the ITypeMatcher type
			// if the call was matched by generic types - there is nothing to check here
			return true;
		}
		else if (value is T typedValue)
		{
			return IsMatching(typedValue);
		}
		else if (value == null && default(T) == null)
		{
			return IsMatching(default!);
		}
		else
		{
			throw new ArgumentException($"A {typeof(T).FullName} was expected but {typeof(Tin).FullName} was received.", nameof(value));
		}
	}

	public static implicit operator ValueConstraint<T>(T exactValue)
	{
		return new ValueConstraint<T>(exactValue);
	}

	public static implicit operator ValueConstraint<T>(Expression<Func<T, bool>> exactValue)
	{
		return new ValueConstraint<T>(exactValue);
	}
}
