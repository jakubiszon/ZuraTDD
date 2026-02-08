using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A procdessor which adds information about the service name
/// and returns <see cref="ExpectedNamedServiceCall" /> for later use.
/// </summary>
public class ExpectedServiceCallOwnerName : IExpectedServiceCallProcessor
{
	public string Name { get; }

	public ExpectedServiceCallOwnerName(string name)
	{
		this.Name = name;
	}

	public ExpectedServiceCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		return new ExpectedNamedServiceCall(
			method,
			this.Name,
			valueSetConstraint,
			expectedCallCount);
	}
}
