using System.Collections.Generic;
using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// An object which defines a set of filter values and a chain of behaviors
/// to apply when the filters match.
/// </summary>
public class BehaviorSetup : IDependencySetup
{
	internal BehaviorSetup(
		ZuraMethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		IEnumerable<IBehavior> behaviors)
	{
		this.Method = methodInfo;
		this.ValueSetConstraint = valueSetConstraint;
		this.GenericTypeParameterSetConstraint = genericTypeParameterSetConstraint;
		this.BehaviorInvoker = new(behaviors);
	}

	public ZuraMethodInfo Method { get; }

	/// <summary>
	/// Value set constraint that restricts the allowed values for this element.
	/// </summary>
	public ValueSetConstraint ValueSetConstraint { get; }

	public GenericTypeParameterSetConstraint GenericTypeParameterSetConstraint { get; }

	/// <summary>
	/// Behavior invoker to run if the value constraint is satisfied.
	/// </summary>
	public BehaviorInvoker BehaviorInvoker { get; }
}
