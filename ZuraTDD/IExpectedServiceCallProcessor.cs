using System.Reflection;

namespace ZuraTDD;

public interface IExpectedServiceCallProcessor
{
	ExpectedServiceCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount);
}
