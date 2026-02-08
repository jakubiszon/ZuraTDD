using ZuraTDD;
using ZuraTDD.Exceptions;
using ZuraTDD.Tests.Example;
using System.Reflection;

namespace ZuraTDD.Tests;

[TestClass]
public class ExpectedCallTests
{
	private static MethodInfo exampleMethod = typeof(ExpectedCallTests).GetMethods().First();

	[TestMethod]
	public void Verify_ExpectingZeroCalls_WhenNoCallsTracked_DoesNotThrow()
	{
		var expectedCall = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([]),
			exactCallNumber: 0);

		var tracker = new CallTracker();

		// should not throw
		expectedCall.Verify(tracker);
	}

	[TestMethod]
	public void Verify_ExpectingZeroCalls_WhenNoMatchingCallsTracked_DoesNotThrow()
	{
		var expectedCall = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([]),
			exactCallNumber: 0);

		var tracker = new CallTracker();

		// should not throw
		expectedCall.Verify(tracker);
	}

	[TestMethod]
	public void Verify_ExpectingCalls_WhenNoMatchingCallsTracked_Throws()
	{
		var expectedCall = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([]),
			null);

		var tracker = new CallTracker();

		Assert.Throws<ExpectationFailed>(() => expectedCall.Verify(tracker));
	}

	[TestMethod]
	public void Verify_MatchingCalls()
	{
		var tracker = new CallTracker();
		tracker.ReceiveCall(exampleMethod, [1]);
		tracker.ReceiveCall(exampleMethod, [2]);

		var expectedAnyCallsWithOne = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(1)]),
			exactCallNumber: null);

		var expectedNoCallsWithThree = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(3)]),
			exactCallNumber: 0);

		var expectedSingleCallWithTwo = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(2)]),
			exactCallNumber: 1);

		var expectedTwoCallsWithPositiveNumbers = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(x => x > 0)]),
			exactCallNumber: 2);

		// should not throw
		expectedAnyCallsWithOne.Verify(tracker);
		expectedNoCallsWithThree.Verify(tracker);
		expectedSingleCallWithTwo.Verify(tracker);
		expectedTwoCallsWithPositiveNumbers.Verify(tracker);
	}


	[TestMethod]
	public void Verify_Mismatched_Throws()
	{
		var tracker = new CallTracker();
		tracker.ReceiveCall(exampleMethod, [1]);
		tracker.ReceiveCall(exampleMethod, [2]);

		var expectedAnyCallsWithFive = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(5)]),
			exactCallNumber: null);

		var expectedNoCallsWithOne = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(1)]),
			exactCallNumber: 0);

		var expectedTwoCallWithTwo = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(2)]),
			exactCallNumber: 2);

		var expectedNoCallsWithPositiveNumbers = new ExpectedCall(
			method: exampleMethod,
			valueSetConstraint: new ValueSetConstraint([new ValueConstraint<int>(x => x > 0)]),
			exactCallNumber: 0);

		Assert.Throws<ExpectationFailed>(() => expectedAnyCallsWithFive.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedNoCallsWithOne.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedTwoCallWithTwo.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedNoCallsWithPositiveNumbers.Verify(tracker));
	}

	[TestMethod]
	public void Verify_WithFakeService_PositiveCases()
	{
		var fakeEmailSender = new IEmailSender_Fake();

		fakeEmailSender.SendEmailSync(
			to: "bobek@example.com",
			subject: "Hello",
			body: "This is a test email.");

		fakeEmailSender.SendEmailSync(
			to: "robson@example.com",
			subject: "Hello",
			body: "This is a test email.");

		fakeEmailSender.SendEmailSync(
			to: "alberto@example.com",
			subject: "Hello",
			body: "This is a test email.");

		var expectedThreeEmails = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: 3);

		var expectedThreeHellos = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(),
				new ValueConstraint<string>("Hello"),
				new ValueConstraint<string>(x => x.ToUpperInvariant() == "THIS IS A TEST EMAIL."),
			]),
			exactCallNumber: 3);

		var expectedEmailToRobson = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(email => email.StartsWith("robson@")),
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: null);

		var expectedExampleComEmails = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(email => email.EndsWith("@example.com")),
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: 3);

		// none should throw
		var tracker = fakeEmailSender.CallTracker;
		expectedThreeEmails.Verify(tracker);
		expectedThreeHellos.Verify(tracker);
		expectedEmailToRobson.Verify(tracker);
		expectedExampleComEmails.Verify(tracker);
	}

	[TestMethod]
	public void Verify_WithFakeService_NegativeCases()
	{
		var fakeEmailSender = new IEmailSender_Fake();

		fakeEmailSender.SendEmailSync(
			to: "bobek@example.com",
			subject: "Hello",
			body: "This is a test email.");

		fakeEmailSender.SendEmailSync(
			to: "robson@example.com",
			subject: "Hello",
			body: "This is a test email.");

		fakeEmailSender.SendEmailSync(
			to: "alberto@example.com",
			subject: "Hello",
			body: "This is a test email.");

		var expectedZeroEmails = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: 0); // there are 3 calls, should fail

		var expectedFourHellos = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(),
				new ValueConstraint<string>("Hello"),
				new ValueConstraint<string>(x => x.ToUpperInvariant() == "THIS IS A TEST EMAIL."),
			]),
			exactCallNumber: 4); // should fail as the number is 3

		var expectedEmailToJurko = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(email => email.StartsWith("jurko@")), // no matching email
				new ValueConstraint<string>(),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: null);

		var expectedAnyByeByeEmails = new ExpectedCall(
			method: IEmailSender_Methods.SendEmailSync,
			valueSetConstraint: new ValueSetConstraint([
				new ValueConstraint<string>(),
				new ValueConstraint<string>("Bye bye"),
				new ValueConstraint<string>(),
			]),
			exactCallNumber: null);

		var tracker = fakeEmailSender.CallTracker;
		Assert.Throws<ExpectationFailed>(() => expectedZeroEmails.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedFourHellos.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedEmailToJurko.Verify(tracker));
		Assert.Throws<ExpectationFailed>(() => expectedAnyByeByeEmails.Verify(tracker));
	}
}
