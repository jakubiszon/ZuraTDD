using System.Reflection;
using ZuraTDD.Exceptions;

namespace ZuraTDD;

public class ExpectedNamedServiceCall : ExpectedServiceCall, ITestResultExpectation
{
	/// <summary>
	/// Identifies the service name which should verify the expected call.
	/// </summary>
	public string ServiceName { get; }

	public ExpectedNamedServiceCall(
		MethodInfo method,
		string serviceName,
		ValueSetConstraint valueSetConstraint,
		int? expectedCallCount)
		: base(method, valueSetConstraint, expectedCallCount)
	{
		ServiceName = serviceName;
	}

	public void Verify(ITestResult testResult)
	{
		var service = testResult.Services[ServiceName] as FakeService;

		if (service == null)
		{
			throw new IncorrectConfiguration($"The dependency '{ServiceName}' is not configured for 'Expect'. If you used 'When.{ServiceName}.Is()' to configure an instance you cannot use `Expect.{ServiceName}`.");
		}

		base.Verify(service);
	}
}
