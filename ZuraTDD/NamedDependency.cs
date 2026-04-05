namespace ZuraTDD;

/// <summary>
/// An abstract, type-less instance of a dependency and a name.
/// The dependency will be passed to a test-subject as a specific param matching the name.
/// </summary>
public interface INamedDependencyInstance
	: INamedDependencySetup
	, IDependencyConfiguration
{
	object? Instance { get; }
}

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
public class NamedDependency<T> : INamedDependencyInstance
{
	public T Instance { get; }

	public string DependencyName { get; }

	object? INamedDependencyInstance.Instance => Instance;

	public NamedDependency(T instance, string dependencyName)
	{
		this.Instance = instance;
		this.DependencyName = dependencyName;
	}

	public IDependencySetup Build()
	{
		return this;
	}
}
