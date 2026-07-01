using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

public interface IExpectedDependencyCallProcessor
{
	ExpectedMockedObjectMethodCall Process(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		int? expectedCallCount);
}
