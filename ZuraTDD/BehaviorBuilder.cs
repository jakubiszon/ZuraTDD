using System.Collections.Generic;
using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// Base class inherited by FuncBehaviorBuilder and ActionBehaviorBuilder classes.
/// </summary>
public abstract class BehaviorBuilder
	: IBehaviorBuilder
{
	public ZuraMethodInfo Method { get; }

	public ValueSetConstraint ValueSetConstraint { get; }

	public GenericTypeParameterSetConstraint GenericTypeParameterSetConstraint { get; }

	private IBehaviorSetupProcessor SetupProcessor { get; }

	private List<IBehavior> behaviors = new List<IBehavior>();

	public IReadOnlyList<IBehavior> Behaviors => this.behaviors.AsReadOnly();

	protected BehaviorBuilder(
		ZuraMethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
	{
		this.Method = methodInfo;
		this.ValueSetConstraint = valueSetConstraint;
		this.GenericTypeParameterSetConstraint = genericTypeParameterSetConstraint;
		this.SetupProcessor = setupProcessor;

		// notify the processor that a new build has started
		this.SetupProcessor.BuildInitiated(this);
	}

	public void Add(IBehavior behavior)
	{
		this.behaviors.Add(behavior);
	}

	public IDependencySetup Build()
	{
		return this.SetupProcessor.Build(this);
	}
}
