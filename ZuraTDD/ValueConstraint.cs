using System;
using System.Linq.Expressions;

namespace ZuraTDD;

/// <summary>
/// An object defining constraints on a value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Type of value.</typeparam>
public class ValueConstraint<T> : IValueConstraint<T>
{
	private Expression<Func<T, bool>>? valueConstraint;

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
		if (value is T typedValue)
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
