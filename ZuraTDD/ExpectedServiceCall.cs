using System;
using System.Reflection;

namespace ZuraTDD;

public class ExpectedServiceCall : ITestPart
{
	private readonly MethodInfo method;
	private readonly ValueSetConstraint valueSetConstraint;
	private readonly int? expectedCallCount;

	public ExpectedServiceCall(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		this.method = method;
		this.valueSetConstraint = valueSetConstraint;
		this.expectedCallCount = expectedCallCount;
	}

	public void Verify(FakeService service)
	{
		if (service == null)
			throw new ArgumentNullException(nameof(service));

		// prepare the expected call object
		var expectedCall = new ExpectedCall(
			this.method,
			this.valueSetConstraint,
			this.expectedCallCount);

		// verify or throw
		expectedCall.Verify(service.CallTracker);
	}
}
