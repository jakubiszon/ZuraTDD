namespace ZuraTDD.Tests.Example;

internal class IEmailSender_NamedInstanceBuilder : IEmailSender_BehaviorBuilder
{
	public IEmailSender_NamedInstanceBuilder(string serviceName)
		: base(new BehaviorSetupOwnerName(serviceName))
	{
	}
}
