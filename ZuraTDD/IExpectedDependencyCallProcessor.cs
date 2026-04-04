using System.Reflection;

namespace ZuraTDD;

public interface IExpectedDependencyCallProcessor
{
	ExpectedDependencyCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount);
}
