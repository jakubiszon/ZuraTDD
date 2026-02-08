namespace ZuraTDD.Tests.Example;

[TestClass]
public class IEmailSender_BehaviorBuilder_Tests
{
	[TestMethod]
	public void SendEmail_Returns_AcceptsValueAndFactory()
	{
		var builder = new IEmailSender_Builder();
		var behaviorSetup = builder
			.SendEmail()
			.Returns((string to, string subject, string body) => Task.CompletedTask)
			.Returns(Task.CompletedTask);

		Assert.HasCount(2, behaviorSetup.Behaviors);
	}

	[TestMethod]
	public void SendEmail_Throws_AcceptsValueAndFactory()
	{
		var builder = new IEmailSender_Builder();
		var behaviorSetup = builder
			.SendEmail()
			.Throws((string to, string subject, string body) => new Exception("exception from factory"))
			.Throws(new Exception("predefined exception"));

		Assert.HasCount(2, behaviorSetup.Behaviors);
	}
}
