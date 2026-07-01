namespace ExampleProject.Insanity;

public interface IDefineGenericMethods
{
	void DoSomething<T>();

	void Test<T>(T value);

	TOutput UseFunc<TInput, TOutput>(Func<TInput, TOutput> func);
}
