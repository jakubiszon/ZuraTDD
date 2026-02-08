using System;

namespace ZuraTDD;

public interface ITestResult
{
	public ITestSubjectServices Services { get; }

	public Exception? Exception { get; }

	public object? Result { get; }
}

public class TestResult<TServices, TResult>
	: ITestResult
	where TServices : class, ITestSubjectServices
{
	public TServices? Services { get; }

	public Exception? Exception { get; }

	public TResult? Result { get; }

	ITestSubjectServices ITestResult.Services => Services!;

	object? ITestResult.Result => Result;

	public TestResult(
		ITestSubjectServices services,
		Exception? exception,
		TResult? result)
	{
		this.Services = services as TServices
			?? throw new ArgumentException($"Invalid service type: {services.GetType().FullName}");

		this.Exception = exception;
		this.Result = result;
	}
}
