using ZuraTDD.Exceptions;
using System;

namespace ZuraTDD;

/// <summary>
/// A marker interface for expectations that represent expected exceptions.
/// It is easier to check for this interface than for the generic <see cref="ExpectedException{TException}"/> type.
/// </summary>
internal interface IExpectedException : ITestResultExpectation
{
}

/// <summary>
/// Represents an exception that is expected to be thrown by the tested method.
/// </summary>
/// <typeparam name="TException">Type of the exception to be expected.</typeparam>
public class ExpectedException<TException> : IExpectedException
	where TException : Exception
{
	public void Verify(ITestResult testResult)
	{
		string exceptionType = typeof(TException).Name;

		if (testResult.Exception == null)
		{
			throw new ExpectationFailed(
				$"An exception of type {exceptionType} was expected but no exception was thrown.");
		}

		if (testResult.Exception is not TException)
		{
			var actualType = testResult.Exception.GetType().Name;
			throw new ExpectationFailed(
				$"An exception of type {exceptionType} was expected but an incompatible exception of type {actualType} was thrown.");
		}
	}
}
