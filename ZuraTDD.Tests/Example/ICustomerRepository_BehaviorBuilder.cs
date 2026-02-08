using ExampleProject;
using ZuraTDD;

namespace ZuraTDD.Tests.Example;

internal abstract class ICustomerRepository_BehaviorBuilder : FakeServiceBuilder
{
	protected ICustomerRepository_BehaviorBuilder(IBehaviorSetupProcessor behaviorSetupProcessor)
		: base(behaviorSetupProcessor)
	{
	}

	public FuncBehaviorBuilder<Task<List<Customer>>> ListAll()
	{
		return new(
			ICustomerRepository_Methods.ListAll,
			this.behaviorSetupProcessor);
	}

	public FuncBehaviorBuilder<string, Task<List<Customer>>> ListByInterests(ValueConstraint<string>? topic = null)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__string,
			new ValueSetConstraint([
				topic ?? new ValueConstraint<string>(),
			]),
			this.behaviorSetupProcessor);
	}

	public FuncBehaviorBuilder<List<string>, Task<List<Customer>>> ListByInterests(ValueConstraint<List<string>>? topics)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__List_string,
			new ValueSetConstraint([
				topics ?? new ValueConstraint<List<string>>(),
			]),
			this.behaviorSetupProcessor);
	}
}
