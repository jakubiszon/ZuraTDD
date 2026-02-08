namespace ZuraTDD;

/// <summary>
/// Defines an object which will process behavior setups.
/// The exact ways of processing can vary greatly.
/// </summary>
public interface IBehaviorSetupProcessor
{
	void BuildInitiated(BehaviorBuilder behaviorSetup);

	/// <summary>
	/// Does something with the setup and returns processing result.
	/// The returned instance could be different that the input.
	/// </summary>
	/// <param name="method">Method to add the setup to.</param>
	/// <param name="behaviorSetup">Behavior setup to add.</param>
	BehaviorSetup Build(BehaviorBuilder behaviorSetup);
}
