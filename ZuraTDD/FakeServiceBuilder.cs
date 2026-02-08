namespace ZuraTDD;

public abstract class FakeServiceBuilder
{
	protected readonly IBehaviorSetupProcessor behaviorSetupProcessor;

	protected FakeServiceBuilder(IBehaviorSetupProcessor behaviorSetupProcessor)
	{
		this.behaviorSetupProcessor = behaviorSetupProcessor;
	}
}
