namespace ZuraTDD;

/// <summary>
/// Defines expected interaction with a service used by the test subject.
/// </summary>
public interface ITestResultExpectation : ITestPart
{
	/// <summary>
	/// Verify that the test target has executed the expectation.
	/// </summary>
	/// <param name="testResult">Result of the test execution.</param>
	void Verify(ITestResult testResult);
}
