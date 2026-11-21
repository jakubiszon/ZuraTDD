namespace ExampleProject.Insanity;

public interface IDefineGenericParam<T>
{
	IEnumerable<T> GetItems();

	void AddItem(T item);
}
