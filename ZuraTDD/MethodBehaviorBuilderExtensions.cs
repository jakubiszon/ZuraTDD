using System;
using System.Threading.Tasks;

namespace ZuraTDD;

public static class MethodBehaviorBuilderExtensions
{
	/// <summary>
	/// Adds a behavior to return a value asynchronously.
	/// The specified value will be wrapped in a Task.
	/// </summary>
	/// <typeparam name="TBuilder">Exact type of func behavior builder.</typeparam>
	/// <typeparam name="Tout">Type of the return value.</typeparam>
	/// <param name="builder">The builder instance.</param>
	/// <param name="value">The return value.</param>
	/// <returns>The builder instance.</returns>
	public static TBuilder ReturnsInTask<TBuilder, Tout>(
		this TBuilder builder,
		Tout value)
		where TBuilder : IFuncBehaviorBuilder<Task<Tout>>
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromResult(value));
		builder.Add(behavior);
		return builder;
	}

	/// <summary>
	/// Adds a behavior to return a value asynchronously.
	/// The value produced by valueFactory param will be wrapped in a Task.
	/// </summary>
	/// <typeparam name="TBuilder">Exact type of func behavior builder.</typeparam>
	/// <typeparam name="Tout">Type of the return value.</typeparam>
	/// <param name="builder">The builder instance.</param>
	/// <param name="valueFactory">A function that produces the return value.</param>
	/// <returns>The builder instance.</returns>
	public static TBuilder ReturnsInTask<TBuilder, Tout>(
		this TBuilder builder,
		Func<Tout> valueFactory)
		where TBuilder : IFuncBehaviorBuilder<ValueTask<Tout>>
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromResult(valueFactory()));
		builder.Add(behavior);
		return builder;
	}

	/// <summary>
	/// Adds a behavior to return a value asynchronously.
	/// The specified value will be wrapped in a Task.
	/// </summary>
	/// <typeparam name="TBuilder">Exact type of func behavior builder.</typeparam>
	/// <typeparam name="Tout">Type of the return value.</typeparam>
	/// <param name="builder">The builder instance.</param>
	/// <param name="value">The return value.</param>
	/// <returns>The builder instance.</returns>
	public static TBuilder ReturnsInValueTask<TBuilder, Tout>(
		this TBuilder builder,
		Tout value)
		where TBuilder : IFuncBehaviorBuilder<ValueTask<Tout>>
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(value));
		builder.Add(behavior);
		return builder;
	}

	/// <summary>
	/// Adds a behavior to return a value asynchronously.
	/// The value produced by valueFactory param will be wrapped in a ValueTask.
	/// </summary>
	/// <typeparam name="TBuilder">Exact type of func behavior builder.</typeparam>
	/// <typeparam name="Tout">Type of the return value.</typeparam>
	/// <param name="builder">The builder instance.</param>
	/// <param name="valueFactory">A function that produces the return value.</param>
	/// <returns>The builder instance.</returns>
	public static TBuilder ReturnsInValueTask<TBuilder, Tout>(
		this TBuilder builder,
		Func<Tout> valueFactory)
		where TBuilder : IFuncBehaviorBuilder<ValueTask<Tout>>
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(valueFactory()));
		builder.Add(behavior);
		return builder;
	}

	/// <summary>
	/// Adds a behavior to return a value.
	/// </summary>
	/// <typeparam name="TBuilder">Exact type of func behavior builder.</typeparam>
	/// <typeparam name="Tout">Type of the return value.</typeparam>
	/// <param name="builder">The builder instance.</param>
	/// <param name="value">The return value.</param>
	/// <returns>The builder instance.</returns>
	public static TBuilder Returns<TBuilder, Tout>(
		this TBuilder builder,
		Tout value)
		where TBuilder : IFuncBehaviorBuilder<Tout>
	{
		var behavior = new ReturnBehavior<Func<Tout>>(() => value);
		builder.Add(behavior);
		return builder;
	}

	public static TBuilder Invokes<TBuilder>(
		this TBuilder builder,
		Action invokedAction)
		where TBuilder : BehaviorBuilder
	{
		var behavior = new SideEffectBehavior<Action>(invokedAction);
		builder.Add(behavior);
		return builder;
	}

	/// <summary>
	/// Adds a throwing behavior. It will throw an exception when the method is called.
	/// For async methods throwing from a task when being awaited - use 
	/// </summary>
	/// <typeparam name="TBuilder"></typeparam>
	/// <param name="builder"></param>
	/// <param name="exception"></param>
	/// <returns></returns>
	public static TBuilder Throws<TBuilder>(
		this TBuilder builder,
		Exception exception)
		where TBuilder : BehaviorBuilder
	{
		var behavior = new ThrowBehavior<Func<Exception>>(() => exception);
		builder.Add(behavior);
		return builder;
	}

	public static TBuilder ThrowsFromTask<TBuilder>(
		this TBuilder builder,
		Exception exception)
		where TBuilder : IFuncBehaviorBuilder<Task>
	{
		var behavior = new ReturnBehavior<Func<Task>>(() => Task.FromException(exception));
		builder.Add(behavior);
		return builder;
	}

	public static TBuilder ThrowsFromValueTask<TBuilder>(
		this TBuilder builder,
		Exception exception)
		where TBuilder : IFuncBehaviorBuilder<ValueTask>
	{
		var behavior = new ReturnBehavior<Func<ValueTask>>(
			() => new ValueTask(Task.FromException(exception)));

		builder.Add(behavior);
		return builder;
	}
}
