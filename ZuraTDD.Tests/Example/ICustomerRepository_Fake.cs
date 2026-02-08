using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal class ICustomerRepository_Fake
	: FakeService
	, ICustomerRepository
{
	public ICustomerRepository_Fake(
		params IEnumerable<BehaviorSetup> behaviors)
		: base(behaviors)
	{
	}

	public Task<List<Customer>> ListAll()
	{
		this.CallTracker.ReceiveCall(
			ICustomerRepository_Methods.ListAll,
			[]);

		return base.BehaviorSetupRunner.InvokeFuncBehavior<Task<List<Customer>>>(
			ICustomerRepository_Methods.ListAll,
			Task.FromResult(new List<Customer>()));
	}

	public Task<List<Customer>> ListByInterests(string topic)
	{
		this.CallTracker.ReceiveCall(
			ICustomerRepository_Methods.ListByInterests__string,
			[topic]);

		return base.BehaviorSetupRunner.InvokeFuncBehavior<string, Task<List<Customer>>>(
			ICustomerRepository_Methods.ListByInterests__string,
			topic,
            Task.FromResult(new List<Customer>()));
    }

    public Task<List<Customer>> ListByInterests(List<string> topics)
	{
		this.CallTracker.ReceiveCall(
			ICustomerRepository_Methods.ListByInterests__List_string,
			[topics]);

		return base.BehaviorSetupRunner.InvokeFuncBehavior<List<string>, Task<List<Customer>>>(
			ICustomerRepository_Methods.ListByInterests__List_string,
			topics,
            Task.FromResult(new List<Customer>()));
    }
}
