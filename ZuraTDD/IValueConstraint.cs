namespace ZuraTDD;

/// <summary>
/// Defines a constraint for a value of any type.
/// </summary>
public interface IValueConstraint
{
	bool IsMatching<T>(T value);
}

/// <summary>
/// Defines a constraint for a value of the type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Type of value to match.</typeparam>
public interface IValueConstraint<T> : IValueConstraint
{
	bool IsMatching(T value);
}
