using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A procdessor which adds information about the dependency name
/// and returns <see cref="ExpectedNamedDependencyCall" /> for later use.
/// </summary>
// TODO: rename this class but note that the name ExpectedNamedDependencyCall is already used
public class ExpectedDependencyCall_NameProcessor : IExpectedDependencyCallProcessor
{
	public string Name { get; }

	public ExpectedDependencyCall_NameProcessor(string name)
	{
		this.Name = name;
	}

	public ExpectedDependencyCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		return new ExpectedNamedDependencyCall(
			method,
			this.Name,
			valueSetConstraint,
			expectedCallCount);
	}
}
