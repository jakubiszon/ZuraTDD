using System;

namespace ZuraTDD.Exceptions;

/// <summary>
/// Thrown when an expectation is not met during test execution.
/// </summary>
public class ExpectationFailed : Exception
{
	public ExpectationFailed(string message)
		: base(message)
	{
	}

	public ExpectationFailed(
		string message,
		Exception innerException)
		: base(message, innerException)
	{ }
}
