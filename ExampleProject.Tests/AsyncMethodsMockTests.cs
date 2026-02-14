using ZuraTDD;

namespace ExampleProject.Tests;

[TestClass]
public class AsyncMethodsMockTests
{
	/// <summary>
	/// Verifies that <see cref="MethodBehaviorBuilderExtensions.Throws" />
	/// creates a behavior which throws an exception before creating a task.
	/// </summary>
	[TestMethod]
	public void TaskMethod_Throws_ThrowsImmediately()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.TaskMethod()
			.Throws(new Exception());

		var instance = buildInstance();

		Assert.Throws<Exception>(instance.TaskMethod);
	}

	[TestMethod]
	public async Task TaskMethod_ThrowsFromTask_ThrowsWhenAwaited()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.TaskMethod()
			.ThrowsFromTask(new Exception());

		var instance = buildInstance();

		// we can create a task and it will only throw when awaited
		var task = instance.TaskMethod();
		await Assert.ThrowsAsync<Exception>(() => task);
	}

	[TestMethod]
	public void TaskOfIntMethod_Throws_ThrowsImmediately()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.TaskOfIntMethod()
			.Throws(new Exception());

		var instance = buildInstance();

		Assert.Throws<Exception>(instance.TaskOfIntMethod);
	}

	[TestMethod]
	public async Task TaskOfIntMethod_ThrowsFromTask_ThrowsWhenAwaited()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.TaskOfIntMethod(null)
			.ThrowsFromTask(new Exception());

		var instance = buildInstance();

		// we can create a task and it will only throw when awaited
		var task = instance.TaskOfIntMethod(123);
		await Assert.ThrowsAsync<Exception>(() => task);
	}

	[TestMethod]
	public void ValueTaskMethod_Throws_ThrowsImmediately()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.ValueTaskMethod()
			.Throws(new Exception());

		var instance = buildInstance();

		Assert.Throws<Exception>(() => instance.ValueTaskMethod());
	}

	[TestMethod]
	public async Task ValueTaskMethod_ThrowsFromTask_ThrowsWhenAwaited()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.ValueTaskMethod()
			.ThrowsFromValueTask(new Exception());

		var instance = buildInstance();

		// we can create a task and it will only throw when awaited
		var valueTask = instance.ValueTaskMethod();
		await Assert.ThrowsAsync<Exception>(async () => await valueTask);
	}

	[TestMethod]
	public void ValueTaskOfIntMethod_Throws_ThrowsImmediately()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.ValueTaskOfIntMethod()
			.Throws(new Exception());

		var instance = buildInstance();

		Assert.Throws<Exception>(() => instance.ValueTaskOfIntMethod());
	}

	[TestMethod]
	public async Task ValueTaskOfIntMethod_ThrowsFromTask_ThrowsWhenAwaited()
	{
		var (setup, buildInstance, buildExpect) = new AsyncMethodsMock();

		setup.ValueTaskOfIntMethod(null)
			.ThrowsFromValueTask(new Exception());

		var instance = buildInstance();

		// we can create a task and it will only throw when awaited
		var valueTask = instance.ValueTaskOfIntMethod(123);
		await Assert.ThrowsAsync<Exception>(async () => await valueTask);
	}
}
