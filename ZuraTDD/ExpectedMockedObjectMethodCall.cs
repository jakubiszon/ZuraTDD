using System;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A test-part representing a method call made to a mocked-object.
/// </summary>
public class ExpectedMockedObjectMethodCall : ITestPart
{
	private readonly ZuraMethodInfo method;
	private readonly ValueSetConstraint valueSetConstraint;
	private readonly int? expectedCallCount;

	public ExpectedMockedObjectMethodCall(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
	{
		this.method = method;
		this.valueSetConstraint = valueSetConstraint;
		this.expectedCallCount = expectedCallCount;
	}

	/// <summary>
	/// Verification of the call done by a <see cref="ExpectedMethodCall" /> object using the
	/// <see cref="CallTracker" /> of the given <see cref="MockedObject" />."
	/// </summary>
	/// <param name="mockedObject">The mocked object whose call tracker will be used for verification.</param>
	/// <exception cref="ArgumentNullException">Thrown if the mocked object is null.</exception>
	public void Verify(MockedObject mockedObject)
	{
		if (mockedObject == null)
			throw new ArgumentNullException(nameof(mockedObject));

		// prepare the expected call object
		var expectedCall = new ExpectedMethodCall(
			this.method,
			this.valueSetConstraint,
			this.expectedCallCount);

		// verify or throw
		expectedCall.Verify(mockedObject.CallTracker);
	}
}
