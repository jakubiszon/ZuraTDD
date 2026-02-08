using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class IEmailSender_StaticBuilder : IEmailSender_BehaviorBuilder
{
	public IEmailSender_StaticBuilder(string serviceName)
		: base(new BehaviorSetupOwnerName(serviceName))
	{
	}
}
