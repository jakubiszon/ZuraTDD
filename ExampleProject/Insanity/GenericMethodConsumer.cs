namespace ExampleProject.Insanity;

public class GenericMethodConsumer
{
	private readonly IDefineGenericMethods genericMethods;
	private readonly IDefineGenericWhereMethods genericMethodsWithWhere;

	public GenericMethodConsumer(
		IDefineGenericMethods genericMethods,
		IDefineGenericWhereMethods genericMethodsWithWhere)
	{
		this.genericMethods = genericMethods;
		this.genericMethodsWithWhere = genericMethodsWithWhere;
	}

	public void SomeMethod(int x)
	{
		if (x == 1)
		{
			this.genericMethods.DoSomething<int>();
		}

		if (x == 2)
		{
			this.genericMethodsWithWhere.DoSomething<IEnumerable<int>, int, object>();
		}
	}
}
