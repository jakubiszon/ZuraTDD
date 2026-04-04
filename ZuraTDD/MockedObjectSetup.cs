namespace ZuraTDD;

public abstract class MockedObjectSetup
	<TSetup, TObjectType, TTester>
{
	public TSetup Setup { get; }

	public TObjectType Instance { get; }

	public TTester Expect { get; }

	protected MockedObjectSetup(
		TSetup setup,
		TObjectType instance,
		TTester expect)
	{
		Setup = setup;
		Instance = instance;
		Expect = expect;
	}

	void Destructure(
		out TSetup setup,
		out TObjectType instance,
		out TTester expect)
	{
		setup = Setup;
		instance = Instance;
		expect = Expect;
	}
}
