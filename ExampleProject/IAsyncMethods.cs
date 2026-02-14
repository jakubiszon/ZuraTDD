namespace ExampleProject;

/// <summary>
/// This interface is only used to test async method behaviors.
/// </summary>
public interface IAsyncMethods
{
	Task TaskMethod();

	Task TaskMethod(int x);

	Task<int?> TaskOfIntMethod();

	Task<int> TaskOfIntMethod(int x);

	ValueTask ValueTaskMethod();

	ValueTask ValueTaskMethod(int x);

	ValueTask<int?> ValueTaskOfIntMethod();

	ValueTask<int> ValueTaskOfIntMethod(int x);
}
