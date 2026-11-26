namespace ExampleProject.Insanity;

/// <summary>
/// An example class consuming a dependency which exposes generic type parameters.
/// </summary>
public class GenericDependencyConsumer
{
	private readonly IDefineGenericParam<int> genericDependency;

	public GenericDependencyConsumer(IDefineGenericParam<int> genericDependency)
	{
		this.genericDependency = genericDependency;
	}

	public int AddItemsAndReturnSumFromDependency(params int[] numbers)
	{
		foreach (int i in numbers)
			genericDependency.AddItem(i);

		return genericDependency
			.GetItems()
			.Sum();
	}
}
