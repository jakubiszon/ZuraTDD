namespace ZuraTDD;

/// <summary>
/// Defines a behavior setup processor that does nothing but
/// stores a name which can later be used to identify the service which
/// should receive the behavior.
/// </summary>
public class BehaviorSetupOwnerName : IBehaviorSetupProcessor
{
	public string OwnerName { get; }

	public BehaviorSetupOwnerName(string ownerName)
	{
		this.OwnerName = ownerName;
	}

	public BehaviorSetup Build(
		BehaviorBuilder builder)
	{
		return new BehaviorSetupServiceAssignment(
			builder.Method,
			builder.ValueSetConstraint,
			builder.Behaviors,
			this.OwnerName);
	}

	public void BuildInitiated(BehaviorBuilder behaviorSetup)
	{
		// no action needed
	}
}
