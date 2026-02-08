namespace ZuraTDD.Tests.Example;

[TestClass]
public class IEmailSender_Builder_Tests
{
	[TestMethod]
	public void BuildInstance_ReturnsIEmailSenderFake()
	{
		// arrange
		var builder = new IEmailSender_Builder();

		// act
		var instance = builder!.BuildInstance();

		// assert
		Assert.IsInstanceOfType(instance, typeof(IEmailSender_Fake));
	}

	[TestMethod]
	public async Task BuildInstance_WithSideEffectSetup_MakesObjectCallingSideEffects()
	{
		// arrange
		bool sideEffectCalled = false;
		var builder = new IEmailSender_Builder();

		builder.SendEmail()
			.Invokes(() => sideEffectCalled = true)
			.Returns(Task.CompletedTask);

		// act
		var instance = builder!.BuildInstance();
		await instance.SendEmail(
			to: "to@example.com",
			subject: "Subject",
			body: "Body");

		// assert
		Assert.IsTrue(sideEffectCalled);
	}
}
