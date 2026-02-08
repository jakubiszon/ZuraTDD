using ExampleProject;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// A behavior builder for <see cref="IEmailSender_Fake" />
/// Method definitions are generated based on the method signatures of <see cref="IEmailSender" />.
/// </summary>
internal abstract class IEmailSender_BehaviorBuilder : FakeServiceBuilder
{
	public IEmailSender_BehaviorBuilder(IBehaviorSetupProcessor behaviorSetupProcessor)
		: base(behaviorSetupProcessor)
	{
	}

	public FuncBehaviorBuilder<string, string, string, Task> SendEmail(
		ValueConstraint<string>? to = null,
		ValueConstraint<string>? subject = null,
		ValueConstraint<string>? body = null)
	{
		return new(
			IEmailSender_Methods.SendEmail,
			new ValueSetConstraint([
				to ?? new ValueConstraint<string>(),
				subject ?? new ValueConstraint<string>(),
				body ?? new ValueConstraint<string>(),
			]),
			this.behaviorSetupProcessor);
	}

	public ActionBehaviorBuilder<string, string, string> SendEmailSync(
		ValueConstraint<string>? to = null,
		ValueConstraint<string>? subject = null,
		ValueConstraint<string>? body = null)
	{
		return new(
			IEmailSender_Methods.SendEmailSync,
			new ValueSetConstraint([
				to ?? new ValueConstraint<string>(),
				subject ?? new ValueConstraint<string>(),
				body ?? new ValueConstraint<string>(),
			]),
			this.behaviorSetupProcessor);
	}
}
