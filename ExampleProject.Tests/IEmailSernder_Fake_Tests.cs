using ZuraTDD;

namespace ExampleProject.Tests;

/// <summary>
/// The class constains tests of the auto-generated fake for IEmailSender.
/// </summary>
[TestClass]
public class IEmailSernder_Fake_Tests
{
	[TestMethod]
	public async Task SendEmail_Behavior_Works()
	{
		// Arrange
		bool behaviorWasRun = false;
		var action = () => { behaviorWasRun = true; };

		var fake = new IEmailSender_Builder();
		fake.SendEmail()
			.Invokes(action);

		var emailSender = fake.BuildInstance();

		// Act
		await emailSender.SendEmail(
			"to@example.com",
			"Subject",
			"body");

		// Assert
		var expect = emailSender.GetExpectObject();
		expect.SendEmail(
			to: "to@example.com")
			.WasCalled();

		Assert.IsTrue(behaviorWasRun);
	}
}
