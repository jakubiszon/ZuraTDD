using System;
using System.Collections.Generic;
using System.Text;
using ZuraTDD.Exceptions;

namespace ExampleProject.Tests;

/// <summary>
/// Tests used to verify that mocking a simple interface which contains some generic methods is possible.
/// </summary>
[TestClass]
public class SimpleGenericMethodMockTests
{
	[TestMethod]
	public void WasCalled_SucceedsWhenACallWasMade()
	{
		var (setup, buildInstance, buildExpect) = new SimpleGenericMethodMock();

		var instance = buildInstance();
		instance.Test(42);

		var expect = buildExpect();
		expect
			.Test<int>(42)
			.WasCalled();

	}

	[TestMethod]
	public void WasCalled_FailsWhenNoCallsWereMade()
	{
		var (setup, buildInstance, buildExpect) = new SimpleGenericMethodMock();

		var expect = buildExpect();

		Assert.Throws<ExpectationFailed>(
			() => expect
				.Test<int>(42)
				.WasCalled());
	}

	[TestMethod]
	public void WasNotCalled_FailsWhenCallsWereMade()
	{
		var (setup, buildInstance, buildExpect) = new SimpleGenericMethodMock();

		var instance = buildInstance();
		instance.DoSomething<int>();

		var expect = buildExpect();

		Assert.Throws<ExpectationFailed>(
			() => expect
				.DoSomething<int>()
				.WasNotCalled());
	}

	[TestMethod]
	public void WasNotCalled_SucceedsWhenCallsWereMade_ButGenericTypesAreDifferent()
	{
		var (setup, buildInstance, buildExpect) = new SimpleGenericMethodMock();

		var instance = buildInstance();
		instance.DoSomething<int>();

		var expect = buildExpect();

		// should not throw
		expect
			.DoSomething<string>()
			.WasNotCalled();
	}
}
