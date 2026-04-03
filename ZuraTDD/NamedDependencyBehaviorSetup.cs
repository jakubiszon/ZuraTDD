using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// Defines a behavior setup that holds a name of a service to which it should be assigned to.
/// The name will identify a service within an instance of <see cref="ITestSubjectServices"/>.
/// </summary>
internal class NamedDependencyBehaviorSetup
	: BehaviorSetup
	, INamedDependencySetup
{
	public string DependencyName { get; }

	public NamedDependencyBehaviorSetup(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IEnumerable<IBehavior> behaviors,
		string dependencyName)
		: base(
			methodInfo,
			valueSetConstraint,
			behaviors)
	{
		this.DependencyName = dependencyName;
	}
}
