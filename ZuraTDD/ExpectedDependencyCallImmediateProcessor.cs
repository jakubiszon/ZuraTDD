using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// A processor which immediately verifies expected service calls
/// in the specified <see cref="MockedObject" />.
/// </summary>
public class ExpectedDependencyCallImmediateProcessor
	: IExpectedDependencyCallProcessor
{
	private readonly MockedObject mockedObject;

	public ExpectedDependencyCallImmediateProcessor(
		MockedObject mockedObject)
	{
		this.mockedObject = mockedObject;
	}

	public ExpectedMockedObjectMethodCall Process(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		int? expectedCallCount)
	{
		var expectedCall = new ExpectedMockedObjectMethodCall(
			method,
			valueSetConstraint,
			genericTypeParameterSetConstraint,
			expectedCallCount);

		expectedCall.Verify(mockedObject);

		return expectedCall;
	}
}
