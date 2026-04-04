using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// An object allowing to specify how many times a call should have occurred.
/// </summary>
public class ExpectedDependencyCallBuilder
{
	private readonly MethodInfo method;
	private readonly IExpectedDependencyCallProcessor processor;
	private readonly ValueSetConstraint valueSetConstraint;

	public ExpectedDependencyCallBuilder(
		MethodInfo method,
		ValueSetConstraint valueSetConstraint,
		IExpectedDependencyCallProcessor processor)
	{
		this.method = method;
		this.processor = processor;
		this.valueSetConstraint = valueSetConstraint;
	}

	public ExpectedDependencyCallBuilder(
		MethodInfo method,
		IValueConstraint[] valueConstraints,
		IExpectedDependencyCallProcessor processor)
	{
		this.method = method;
		this.processor = processor;
		this.valueSetConstraint = new ValueSetConstraint(valueConstraints);
	}

	public ExpectedDependencyCall WasNotCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			0);
	}

	public ExpectedDependencyCall WasCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			null);
	}

	public ExpectedDependencyCall WasCalled(int times)
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			times);
	}
}
