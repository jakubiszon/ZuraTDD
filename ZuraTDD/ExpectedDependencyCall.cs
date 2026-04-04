using System;
using System.Reflection;

namespace ZuraTDD;

public class ExpectedDependencyCall : ITestPart
{
	private readonly MethodInfo method;
	private readonly ValueSetConstraint valueSetConstraint;
	private readonly int? expectedCallCount;

	public ExpectedDependencyCall(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		this.method = method;
		this.valueSetConstraint = valueSetConstraint;
		this.expectedCallCount = expectedCallCount;
	}

	public void Verify(MockedObject mockedObject)
	{
		if (mockedObject == null)
			throw new ArgumentNullException(nameof(mockedObject));

		// prepare the expected call object
		var expectedCall = new ExpectedCall(
			this.method,
			this.valueSetConstraint,
			this.expectedCallCount);

		// verify or throw
		expectedCall.Verify(mockedObject.CallTracker);
	}
}
