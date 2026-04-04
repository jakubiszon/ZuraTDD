using System.Reflection;
using ZuraTDD.Exceptions;

namespace ZuraTDD;

public class ExpectedNamedDependencyCall : ExpectedMockedObjectMethodCall, ITestResultExpectation
{
	/// <summary>
	/// Identifies the dependency name which should verify the expected call.
	/// </summary>
	public string DependencyName { get; }

	public ExpectedNamedDependencyCall(
		MethodInfo method,
		string dependencyName,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
		: base(method, valueSetConstraint, expectedCallCount)
	{
		DependencyName = dependencyName;
	}

	public void Verify(ITestResult testResult)
	{
		if (testResult.Dependencies[DependencyName] is not MockedObject mockedObject)
		{
			throw new IncorrectConfiguration($"The dependency '{DependencyName}' is not configured for 'Expect'. If you used 'When.{DependencyName}.Is()' to configure an instance you cannot use `Expect.{DependencyName}`.");
		}

		base.Verify(mockedObject);
	}
}
