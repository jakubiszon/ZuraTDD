using System.Collections.Generic;

namespace ZuraTDD;

/// <summary>
/// Base class for fake objects.
/// </summary>
public abstract class FakeService
{
	public CallTracker CallTracker { get; }

	protected BehaviorSetupRunner BehaviorSetupRunner { get; }

	protected FakeService(
		IEnumerable<BehaviorSetup> behaviorSetups)
	{
		CallTracker = new();
		BehaviorSetupRunner = new BehaviorSetupRunner(behaviorSetups);
	}
}
