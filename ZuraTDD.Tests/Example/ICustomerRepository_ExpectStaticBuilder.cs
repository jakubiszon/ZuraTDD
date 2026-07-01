using ZuraTDD.BuildingBlocks;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// An expectation setup object for <see cref="ICustomerRepository" />.
/// </summary>
internal class ICustomerRepository_Expect
	: ICustomerRepository_ExpectBuilder
{
	public ICustomerRepository_Expect(
		MockedObject existingFake)
		: base(new ExpectedDependencyCallImmediateProcessor(existingFake))
	{
	}
}

internal class ICustomerRepository_ExpectStaticBuilder
	: ICustomerRepository_ExpectBuilder
{
	public ICustomerRepository_ExpectStaticBuilder(
		string serviceName)
		: base(new ExpectedDependencyCallNameProcessor(serviceName))
	{
	}
}

internal class ICustomerRepository_ExpectBuilder
{
	private IExpectedDependencyCallProcessor processor;

	protected ICustomerRepository_ExpectBuilder(
		IExpectedDependencyCallProcessor processor)
	{
		this.processor = processor;
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListAll" />.
	/// </summary>
	public ExpectedDependencyCallBuilder ListAll()
	{
		return new(
			ICustomerRepository_Methods.ListAll,
			new ValueSetConstraint([
				
			]),
			new GenericTypeParameterSetConstraint([]),
			this.processor);
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListByInterests" />.
	/// </summary>
	public ExpectedDependencyCallBuilder ListByInterests(
		ValueConstraint<string>? topic = null)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__string,
			new ValueSetConstraint([
				topic ?? new ValueConstraint<string>()
			]),
			new GenericTypeParameterSetConstraint([]),
			this.processor);
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListByInterests" />.
	/// </summary>
	public ExpectedDependencyCallBuilder ListByInterests(
		ValueConstraint<System.Collections.Generic.List<string>>? topics = null)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__List_string,
			new ValueSetConstraint([
				topics ?? new ValueConstraint<System.Collections.Generic.List<string>>()
			]),
			new GenericTypeParameterSetConstraint([]),
			this.processor);
	}
}
