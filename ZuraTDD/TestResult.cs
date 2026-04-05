using System;

namespace ZuraTDD;

public interface ITestResult
{
	public ITestSubjectDependencies Dependencies { get; }

	public Exception? Exception { get; }

	public object? Result { get; }
}

public class TestResult<TTestSubjectDependencies, TResult>
	: ITestResult
	where TTestSubjectDependencies : class, ITestSubjectDependencies
{
	public TTestSubjectDependencies? Dependencies { get; }

	public Exception? Exception { get; }

	public TResult? Result { get; }

	ITestSubjectDependencies ITestResult.Dependencies => Dependencies!;

	object? ITestResult.Result => Result;

	public TestResult(
		ITestSubjectDependencies dependencies,
		Exception? exception,
		TResult? result)
	{
		this.Dependencies = dependencies as TTestSubjectDependencies
			?? throw new ArgumentException($"Invalid ITestSubjectDependencies type passed '{dependencies.GetType().FullName}' but was expected to be '{typeof(TTestSubjectDependencies).FullName}'");

		this.Exception = exception;
		this.Result = result;
	}
}
