using System.Collections.Generic;

namespace ZuraTDD;

/// <summary>
/// Base class for mocked-objects. All auto-generated classes which implement interfaces used in the tested code
/// will inhetic this class.
/// </summary>
public abstract class MockedObject
{
	public CallTracker CallTracker { get; }

	protected BehaviorSetupRunner BehaviorSetupRunner { get; }

	protected MockedObject(
		IEnumerable<BehaviorSetup> behaviorSetups)
	{
		CallTracker = new();
		BehaviorSetupRunner = new BehaviorSetupRunner(behaviorSetups);
	}
}
