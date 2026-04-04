namespace ZuraTDD;

public abstract class MockedObjectBuilder
{
	protected readonly IBehaviorSetupProcessor behaviorSetupProcessor;

	protected MockedObjectBuilder(IBehaviorSetupProcessor behaviorSetupProcessor)
	{
		this.behaviorSetupProcessor = behaviorSetupProcessor;
	}
}
