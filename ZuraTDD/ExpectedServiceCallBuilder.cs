using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// An object allowing to specify how many times a call should have occurred.
/// </summary>
public class ExpectedServiceCallBuilder
{
	private readonly MethodInfo method;
	private readonly IExpectedServiceCallProcessor processor;
	private readonly ValueSetConstraint valueSetConstraint;

	public ExpectedServiceCallBuilder(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		IExpectedServiceCallProcessor processor)
	{
		this.method = method;
		this.processor = processor;
		this.valueSetConstraint = valueSetConstraint;
	}

	public ExpectedServiceCallBuilder(
		MethodInfo method,
		IValueConstraint[] valueConstraints,
		IExpectedServiceCallProcessor processor)
	{
		this.method = method;
		this.processor = processor;
		this.valueSetConstraint = new ValueSetConstraint(valueConstraints);
	}

	public ExpectedServiceCall WasNotCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			0);
	}

	public ExpectedServiceCall WasCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			null);
	}

	public ExpectedServiceCall WasCalled(int times)
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			times);
	}
}
