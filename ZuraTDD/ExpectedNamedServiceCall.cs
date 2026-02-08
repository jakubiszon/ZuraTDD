using System.Reflection;

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
		var service = testResult.Services[ServiceName];
		base.Verify(service);
	}
}
