using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class ICustomerRepository_StaticBuilder : ICustomerRepository_BehaviorBuilder
{
	public ICustomerRepository_StaticBuilder(string serviceName)
		: base(new BehaviorSetupOwnerName(serviceName))
	{
	}
}
