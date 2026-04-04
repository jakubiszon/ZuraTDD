using System.Reflection;

namespace ZuraTDD;

public interface IExpectedDependencyCallProcessor
{
	ExpectedMockedObjectMethodCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount);
}
