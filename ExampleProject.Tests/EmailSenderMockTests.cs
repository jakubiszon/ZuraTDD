namespace ExampleProject.Tests;

/// <summary>
/// This class is used to verify mocking code generated for <see cref="IEmailSender"/>.
/// </summary>
[TestClass]
public class EmailSenderMockTests
{
	[TestMethod]
	public void MockObject_Deconstruct_ReturnsWorkingObjects()
	{
		var (setup, buildInstance, buildExpect) = new EmailSenderMock();

		Assert.IsNotNull(setup);
		Assert.IsNotNull(buildInstance());
		Assert.IsNotNull(buildExpect());
	}

	[TestMethod]
	public void MockObject_SetupSideEffect()
	{
		var (setup, buildInstance, buildExpect) = new EmailSenderMock();
		bool sideEffectCalled = false;

		setup.SendEmailSync()
			.Invokes(() => sideEffectCalled = true);

		var instance = buildInstance();
		instance.SendEmailSync(
			to: "email@example.com",
			subject: "very important message",
			body: "sorry it's just spam :D");

		Assert.IsTrue(sideEffectCalled);

		var expect = buildExpect();
		expect.SendEmailSync(
			to: "email@example.com")
			.WasCalled();
	}

	[TestMethod]
	public void MockObject_SetupException()
	{
		var (setup, buildInstance, buildExpect) = new EmailSenderMock();
		bool sideEffectCalled = false;

		setup.SendEmailSync()
			.Invokes(() => sideEffectCalled = true)
			.Throws(new InvalidOperationException("some error"));

		var instance = buildInstance();
		Assert.Throws<InvalidOperationException>(
			() => instance.SendEmailSync(
				to: "email@example.com",
				subject: "very important message",
				body: "sorry it's just spam :D"));

		Assert.IsTrue(sideEffectCalled);

		var expect = buildExpect();
		expect.SendEmailSync(
			to: "email@example.com")
			.WasCalled();
	}
}
