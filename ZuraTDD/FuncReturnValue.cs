namespace ZuraTDD;

/// <summary>
/// A wrapper for simulated method return values.
/// Note that <see langword="null" /> is a valid return value but needs to be wrapped in this object too.
/// </summary>
/// <typeparam name="Tout"></typeparam>
public class FuncReturnValue<Tout>
{
	public Tout Value { get; }

	public FuncReturnValue(Tout value)
	{
		this.Value = value;
	}

	public static explicit operator FuncReturnValue<Tout>(Tout value)
	{
		return new(value);
	}
}
