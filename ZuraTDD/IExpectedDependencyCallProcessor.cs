using System.Reflection;

namespace ZuraTDD;

public interface IExpectedDependencyCallProcessor
{
	ExpectedMockedObjectMethodCall Process(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount);
}
