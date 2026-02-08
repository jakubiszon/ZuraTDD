using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class IEmailSender_Fake
	: FakeService
	, IEmailSender
{
	public IEmailSender_Fake(
		params IEnumerable<BehaviorSetup> behaviorSetups)
		: base(behaviorSetups)
	{
	}

	public Task SendEmail(string to, string subject, string body)
	{
		this.CallTracker.ReceiveCall(
			IEmailSender_Methods.SendEmail,
			[
				to,
				subject,
				body,
			]);

		return base.BehaviorSetupRunner.InvokeFuncBehavior<string, string, string, Task>(
			IEmailSender_Methods.SendEmail,
			to,
			subject,
			body,
			Task.CompletedTask);
	}

	public void SendEmailSync(string to, string subject, string body)
	{
		this.CallTracker.ReceiveCall(
			IEmailSender_Methods.SendEmailSync,
			[
				to,
				subject,
				body,
			]);

		base.BehaviorSetupRunner.InvokeActionBehavior(
			IEmailSender_Methods.SendEmailSync,
			to,
			subject,
			body);
	}
}
