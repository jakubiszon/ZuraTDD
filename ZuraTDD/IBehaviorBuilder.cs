namespace ZuraTDD;

public interface IBehaviorBuilder : IDependencyConfiguration
{
	void Add(IBehavior behavior);
}
