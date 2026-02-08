namespace ZuraTDD.Tests.Example;

internal class IEmailSender_Builder
	: IEmailSender_BehaviorBuilder
	, IBuild<IEmailSender_Fake>
{
	public IEmailSender_Builder()
		: base(new BehaviorSetupCollector())
	{
	}

	public IEmailSender_Fake BuildInstance()
	{
		var collector = base.behaviorSetupProcessor as BehaviorSetupCollector;

		return new IEmailSender_Fake(
			collector!.BuildSetupCollection());
	}
}
