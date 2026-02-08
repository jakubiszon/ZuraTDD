namespace ZuraTDD;

/// <summary>
/// Defines an object which can build instances of <see cref="{T}" />.
/// </summary>
/// <typeparam name="T">Type of objects the object can build.</typeparam>
public interface IBuild<T>
{
	public T BuildInstance();
}
