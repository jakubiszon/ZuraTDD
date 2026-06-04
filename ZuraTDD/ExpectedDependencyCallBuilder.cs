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

	/// <summary>
	/// Builds an expectation that the method call is not matched at all.
	/// </summary>
	public ExpectedMockedObjectMethodCall WasNotCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			0);
	}

	/// <summary>
	/// Builds an expectation that the method call is matched at least once, without specifying how many times exactly.
	/// </summary>
	public ExpectedMockedObjectMethodCall WasCalled()
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			null);
	}

	/// <summary>
	/// Builds an expectation that the method call is matched a specific number of times.
	/// </summary>
	/// <param name="times">Number of times to expect the method call to be matched.</param>
	public ExpectedMockedObjectMethodCall WasCalled(int times)
	{
		return processor.Process(
			this.method,
			this.valueSetConstraint,
			times);
	}
}
