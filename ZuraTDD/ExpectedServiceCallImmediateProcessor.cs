using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A processor which immediately verifies expected service calls
/// in the specified <see cref="MockedObject" />.
/// </summary>
public class ExpectedServiceCallImmediateProcessor
	: IExpectedDependencyCallProcessor
{
	private readonly MockedObject mockedObject;

	public ExpectedServiceCallImmediateProcessor(
		MockedObject mockedObject)
	{
		this.mockedObject = mockedObject;
	}

	public ExpectedDependencyCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		var expectedCall = new ExpectedDependencyCall(
			method,
			valueSetConstraint,
			expectedCallCount);

		expectedCall.Verify(mockedObject);

		return expectedCall;
	}
}
