using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// Defines a behavior setup that holds a name of a service to which it should be assigned.
/// The name will identify a service within an instance of <see cref="ITestSubjectServices"/>.
/// </summary>
internal class BehaviorSetupServiceAssignment : BehaviorSetup
{
	public string ServiceName { get; }

	public BehaviorSetupServiceAssignment(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IEnumerable<IBehavior> behaviors,
		string serviceName)
		: base(
			methodInfo,
			valueSetConstraint,
			behaviors)
	{
		this.ServiceName = serviceName;
	}
}
