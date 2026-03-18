using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class IEmailSender_StaticExpectedCallBuilder : IEmailSender_ExpectBuilder
{
	public IEmailSender_StaticExpectedCallBuilder(string serviceName)
		: base(new ExpectedServiceCallOwnerName(serviceName))
	{
	}
}
