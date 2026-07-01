using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// A procdessor which adds information about the dependency name
/// and returns <see cref="ExpectedNamedDependencyCall" /> for later use.
/// </summary>
// TODO: rename this class but note that the name ExpectedNamedDependencyCall is already used
public class ExpectedDependencyCallNameProcessor : IExpectedDependencyCallProcessor
{
	public string Name { get; }

	public ExpectedDependencyCallNameProcessor(string name)
	{
		this.Name = name;
	}

	public ExpectedMockedObjectMethodCall Process(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		int? expectedCallCount)
	{
		return new ExpectedNamedDependencyCall(
			method,
			this.Name,
			valueSetConstraint,
			genericTypeParameterSetConstraint,
			expectedCallCount);
	}
}
