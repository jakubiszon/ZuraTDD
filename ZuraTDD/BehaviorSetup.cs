using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// An object which defines a set of filter values and a chain of behaviors
/// to apply when the filters match.
/// </summary>
public class BehaviorSetup : ITestPart
{
	internal BehaviorSetup(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IEnumerable<IBehavior> behaviors)
	{
		this.Method = methodInfo;
		this.ValueSetConstraint = valueSetConstraint;
		this.BehaviorInvoker = new(behaviors);
	}

	public MethodInfo Method { get; }

	/// <summary>
	/// Value set constraint that restricts the allowed values for this element.
	/// </summary>
	public ValueSetConstraint ValueSetConstraint { get; }

	/// <summary>
	/// Behavior invoker to run if the value constraint is satisfied.
	/// </summary>
	public BehaviorInvoker BehaviorInvoker { get; }
}
