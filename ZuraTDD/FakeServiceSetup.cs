namespace ZuraTDD;

public abstract class FakeServiceSetup
	<TSetup, TService, TTester>
{
	public TSetup Setup { get; }

	public TService Instance { get; }

	public TTester Expect { get; }

	protected FakeServiceSetup(
		TSetup setup,
		TService instance,
		TTester expect)
	{
		Setup = setup;
		Instance = instance;
		Expect = expect;
	}

	void Destructure(
		out TSetup setup,
		out TService instance,
		out TTester expect)
	{
		setup = Setup;
		instance = Instance;
		expect = Expect;
	}
}
