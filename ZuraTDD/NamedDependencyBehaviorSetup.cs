using System.Collections.Generic;
using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// Defines a behavior setup that holds a name of a service to which it should be assigned to.
/// The name will identify a service within an instance of <see cref="ITestSubjectDependencies"/>.
/// </summary>
internal class NamedDependencyBehaviorSetup
	: BehaviorSetup
	, INamedDependencySetup
{
	public string DependencyName { get; }

	public NamedDependencyBehaviorSetup(
		ZuraMethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		GenericTypeParameterSetConstraint genericTypeParameterSetConstraint,
		IEnumerable<IBehavior> behaviors,
		string dependencyName)
		: base(
			methodInfo,
			valueSetConstraint,
			genericTypeParameterSetConstraint,
			behaviors)
	{
		this.DependencyName = dependencyName;
	}
}
