namespace ZuraTDD;

/// <summary>
/// An object used to pass a dependency instance directly without mocking it.
/// <br />When is it needed:
/// <list type="bullet">
/// <item>The user wants a specific object to be passed to the test.</item>
/// <item>TestTarget constructor accepts a simple value (e.g. a string).</item>
/// <item>TestTarget constructor accepts an object which is hard to mock.</item>
/// </list>
/// </summary>
/// <typeparam name="T">Type of object used as a dependency.</typeparam>
public class NamedDependency<T> : IDependencySetup
{
	public T Instance { get; }

	public string ServiceName { get; }

	public NamedDependency(T instance, string serviceName)
	{
		this.Instance = instance;
		this.ServiceName = serviceName;
	}
}
