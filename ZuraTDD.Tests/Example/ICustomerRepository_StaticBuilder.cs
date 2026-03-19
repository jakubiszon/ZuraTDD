using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class ICustomerRepository_StaticBuilder : ICustomerRepository_BehaviorBuilder
{
	private string serviceName;

	public ICustomerRepository_StaticBuilder(string serviceName)
		: base(new BehaviorSetupOwnerName(serviceName))
	{
		this.serviceName = serviceName;
	}

	/// <summary>
	/// Returns a TestPart which will make the TestSubject receive the specified instance as its dependency.
	/// </summary>
	/// <param name="instance">Instance of ICustomerRepository used as dependency.</param>
	public NamedDependency<ICustomerRepository> Is(ICustomerRepository instance)
	{
		return new (
			instance,
			this.serviceName);
	}
}
