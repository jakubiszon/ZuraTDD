namespace ZuraTDD.Tests.Example;

/// <summary>
/// An expectation setup object for <see cref="ICustomerRepository" />.
/// </summary>
internal class ICustomerRepository_Expect
	: ICustomerRepository_ExpectBuilder
{
	public ICustomerRepository_Expect(
		FakeService existingFake)
		: base(new ExpectedServiceCallImmediateProcessor(existingFake))
	{
	}
}

internal class ICustomerRepository_ExpectStaticBuilder
	: ICustomerRepository_ExpectBuilder
{
	public ICustomerRepository_ExpectStaticBuilder(
		string serviceName)
		: base(new ExpectedServiceCallOwnerName(serviceName))
	{
	}
}

internal class ICustomerRepository_ExpectBuilder
{
	private IExpectedServiceCallProcessor processor;

	protected ICustomerRepository_ExpectBuilder(
		IExpectedServiceCallProcessor processor)
	{
		this.processor = processor;
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListAll" />.
	/// </summary>
	public ExpectedServiceCallBuilder ListAll()
	{
		return new(
			ICustomerRepository_Methods.ListAll,
			new ValueSetConstraint([
				
			]),
			this.processor);
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListByInterests" />.
	/// </summary>
	public ExpectedServiceCallBuilder ListByInterests(
		ValueConstraint<string>? topic = null)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__string,
			new ValueSetConstraint([
				topic ?? new ValueConstraint<string>()
			]),
			this.processor);
	}

	/// <summary>
	/// Builds call expectations for <see cref="ICustomerRepository.ListByInterests" />.
	/// </summary>
	public ExpectedServiceCallBuilder ListByInterests(
		ValueConstraint<System.Collections.Generic.List<string>>? topics = null)
	{
		return new(
			ICustomerRepository_Methods.ListByInterests__List_string,
			new ValueSetConstraint([
				topics ?? new ValueConstraint<System.Collections.Generic.List<string>>()
			]),
			this.processor);
	}
}
