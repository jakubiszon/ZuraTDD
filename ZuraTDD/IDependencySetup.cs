namespace ZuraTDD;

/// <summary>
/// Represents a finalized setup of a dependency or its behavior which is used by a test subject when running a test case.
/// </summary>
public interface IDependencySetup : ITestPart
{
}

/// <summary>
/// A finalized setup of a dependency or its behavior which is also assigned a name.
/// </summary>
public interface INamedDependencySetup : IDependencySetup
{
	/// <summary>
	/// Name of the dependency within a set of services/dependencies of a test subject.
	/// </summary>
	string DependencyName { get; }
}
