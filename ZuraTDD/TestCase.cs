using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ZuraTDD.Exceptions;

namespace ZuraTDD;

[DataContract]
public abstract class TestCase
{
	[DataMember]
	public string Name { get; }

	public ITestedMethodCall ReceivedCall { get; }

	public IReadOnlyList<BehaviorSetup> WhenConditions { get; }

	public IReadOnlyList<ITestResultExpectation> Expectations { get; }

	protected TestCase(
		string name,
		params ITestPart[] testParts)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new IncorrectConfiguration(
				"Test case must be named.");
		}

		if ((testParts?.Length ?? 0) == 0)
		{
			throw new IncorrectConfiguration(
				$"Test case '{name}' must have at least one test part.");
		}

		if (testParts!.OfType<ITestedMethodCall>().Count() != 1)
		{
			throw new IncorrectConfiguration(
				$"Test case '{name}' must start with a single tested method call.");
		}

		this.Name = name;

		this.ReceivedCall = testParts!.First() as ITestedMethodCall
			?? throw new IncorrectConfiguration(
				$"Test case '{name}' must start with a tested method call.");

		this.WhenConditions = testParts!
			.OfType<BehaviorBuilder>()
			.Select(builder => builder.ToBehaviorSetup())
			.ToArray();

		this.Expectations = testParts!
			.OfType<ITestResultExpectation>()
			.ToArray();

		// note: WhenConditions and Expectations can both be empty when we only want to test
		//       that no exception is thrown from the received call
	}

	public override string ToString()
	{
		return this.Name;
	}

	/// <summary>
	/// Executes the test case using its defined behaviors and verifies its expectations.
	/// </summary>
	/// <remarks>
	/// Any synchronous test will also be tested with this method just to make it easier.
	/// If you have ideas on how to improve this - PRs are welcome :D
	/// </remarks>
	public abstract Task RunTestAsync();

	protected void Verify(ITestResult result)
	{
		if(result.Exception is not null)
		{
			VerifyException(result.Exception);
		}

		foreach (var expectation in Expectations)
		{
			expectation.Verify(result);
		}
	}

	/// <summary>
	/// Verifies that an exception was expected when one was thrown by the tested method.
	/// </summary>
	/// <param name="ex">Exception that was thrown by the tested method.</param>
	/// <exception cref="AssertFailedException">Thrown when no exception was defined in the expectations.</exception>
	/// <remarks>
	/// This method does not verify exception types or properties.
	/// Even if an exception was expected, that verification is done in the individual expectations.
	/// </remarks>
	private void VerifyException(Exception ex)
	{
		bool exceptionWasExpected = this.Expectations.Any(e => e is IExpectedException);
		if(!exceptionWasExpected)
		{
			throw new ExpectationFailed(
				$"An unexpected exception was thrown during the tested method call: {ex.GetType().FullName}: {ex.Message}",
				ex);
		}
	}

	#pragma warning disable IDE0060 // Remove unused parameter
	public static string GetDisplayName(MethodInfo methodInfo, object[] data)
	#pragma warning restore IDE0060 // Remove unused parameter
	{
		if (data.Length > 0 && data[0] is TestCase testCase)
		{
			return testCase.Name;
		}
		else
		{
			throw new Exception("The objects referenced with the [TestCases] attribute must be of type TestCase.");
		}
	}

	public static implicit operator object[](TestCase testCase)
	{
		return new object[] { testCase };
	}
}

public abstract class TestCase<TestSubject, TestSubjectServices>
	: TestCase, ITestCase<TestSubject>
	where TestSubjectServices : class, ITestSubjectServices, new()
{
	public TestCase(
		string name,
		params ITestPart[] testParts)
		: base(name, testParts)
	{
		// TODO: create services instance using the When conditions
	}

	/// <summary>
	/// The services available to the test case.
	/// </summary>
	public TestSubjectServices Services { get; } = new();

	public abstract TestSubject GetTestSubject();

	public override async Task RunTestAsync()
	{
		var testSubject = GetTestSubject();
		this.Services.ApplyBehaviors(this.WhenConditions);

		TestResult<TestSubjectServices, object?> testResult;
		try
		{
			var callResult = await base.ReceivedCall.CallAsync(testSubject!);

			testResult = new TestResult<TestSubjectServices, object?>(
				services: this.Services,
				exception: null,
				result: callResult);

		}
		catch (Exception ex)
		{
			testResult = new TestResult<TestSubjectServices, object?>(
				services: this.Services,
				exception: ex,
				result: null);
		}

		base.Verify(testResult);
	}
}
