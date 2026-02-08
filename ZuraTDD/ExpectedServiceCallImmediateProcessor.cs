using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A processor which immediately verifies expected service calls
/// in the specified <see cref="FakeService" />.
/// </summary>
public class ExpectedServiceCallImmediateProcessor
	: IExpectedServiceCallProcessor
{
	private readonly FakeService fakeService;

	public ExpectedServiceCallImmediateProcessor(
		FakeService fakeService)
	{
		this.fakeService = fakeService;
	}

	public ExpectedServiceCall Process(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		var expectedCall = new ExpectedServiceCall(
			method,
			valueSetConstraint,
			expectedCallCount);

		expectedCall.Verify(fakeService);

		return expectedCall;
	}
}
