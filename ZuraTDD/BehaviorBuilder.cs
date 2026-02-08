using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZuraTDD;

/// <summary>
/// Base class inherited by FuncBehaviorBuilder and ActionBehaviorBuilder classes.
/// </summary>
public abstract class BehaviorBuilder : ITestPart
{
	public MethodInfo Method { get; }

	public ValueSetConstraint ValueSetConstraint { get; }

	private IBehaviorSetupProcessor SetupProcessor { get; }

	private List<IBehavior> behaviors = new List<IBehavior>();

	public IReadOnlyList<IBehavior> Behaviors => this.behaviors.AsReadOnly();

	protected BehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
	{
		this.Method = methodInfo;
		this.ValueSetConstraint = valueSetConstraint;
		this.SetupProcessor = setupProcessor;

		// notify the processor that a new build has started
		this.SetupProcessor.BuildInitiated(this);
	}

	public void Add(IBehavior behavior)
	{
		this.behaviors.Add(behavior);
	}

	public BehaviorSetup ToBehaviorSetup()
	{
		return this.SetupProcessor.Build(this);
	}
}
