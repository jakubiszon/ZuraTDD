using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// A mock implementation of <see cref="ExampleProject.IEmailSender" />.
/// </summary>
internal class IEmailSender_Fake
	: MockedObject
	, ExampleProject.IEmailSender
{
	public IEmailSender_Fake(
		params IEnumerable<BehaviorSetup> behaviors)
		: base(behaviors)
	{
	}

	public IEmailSender_Expect GetExpectObject()
	{
		return new(this);
	}

	/// <summary>
	/// Simulates behavior for <see cref="IEmailSender.SendEmail" />.
	/// </summary>
	public System.Threading.Tasks.Task SendEmail(
		string to,
		string subject,
		string body)
	{
		this.CallTracker.ReceiveCall(
			IEmailSender_Methods.SendEmail,
			[to, subject, body]);

		return base.BehaviorSetupRunner.InvokeFuncBehavior<string, string, string, System.Threading.Tasks.Task>(
			IEmailSender_Methods.SendEmail,
			to, subject, body,
			Task.CompletedTask);
	}

	/// <summary>
	/// Simulates behavior for <see cref="IEmailSender.SendEmailSync" />.
	/// </summary>
	public void SendEmailSync(
		string to,
		string subject,
		string body)
	{
		this.CallTracker.ReceiveCall(
			IEmailSender_Methods.SendEmailSync,
			[to, subject, body]);

		base.BehaviorSetupRunner.InvokeActionBehavior<string, string, string>(
			IEmailSender_Methods.SendEmailSync,
			to, subject, body);
	}
}
