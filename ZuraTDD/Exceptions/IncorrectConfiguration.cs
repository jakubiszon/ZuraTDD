using System;

namespace ZuraTDD.Exceptions;

/// <summary>
/// Thrown when the test configuration is incorrect.
/// </summary>
public class IncorrectConfiguration : Exception
{
	public IncorrectConfiguration(string message)
		: base(message)
	{
	}

	public IncorrectConfiguration(
		string message,
		Exception innerException)
		: base(message, innerException)
	{ }
}
