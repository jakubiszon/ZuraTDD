using System.Collections.Generic;

namespace ZuraTDD;

/// <summary>
/// Base class for fake objects.
/// </summary>
/// <typeparam name="TBuilder">Type of builder used to setup the fake object.</typeparam>
public abstract class FakeService
{
	public CallTracker CallTracker { get; }

	protected BehaviorSetupRunner BehaviorSetupRunner { get; private set; } // TODO setter only needed because of ApplyBehaviors

	protected FakeService(
		IEnumerable<BehaviorSetup> behaviorSetups)
	{
		CallTracker = new();
		BehaviorSetupRunner = new BehaviorSetupRunner(behaviorSetups);
	}

	// TODO: try making both ways of setting up (via instance-builder and static-builder) use the same path
	//       creating new TestSubjectServices instance should accept the behavior sets instead of using this method.
	internal void ApplyBehaviors(IEnumerable<BehaviorSetup> behaviorSetups)
	{
		BehaviorSetupRunner = new BehaviorSetupRunner(behaviorSetups);
	}
}
