using System;
using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD;

// TODO: add type param documentation
// TODO: add method param documentation
// TODO: expand generic params up to 16 - as the limit defined in Func and Action delegates

/// <summary>
/// A stateful object invoking method behaviors - side-effects, return values and exceptions.
/// </summary>
/// <remarks>
/// This class does not know or identify the method for which it invokes behaviors.
/// Method identification and mapping to behaviors is done by <see cref="BehaviorSetupRunner"/>.
/// </remarks>
public class BehaviorInvoker
{
	// stores the index of last executed non "side-effect" behavior
	private int lastUsedBehaviorIndex = -1;

	/// <summary>
	/// List of behaviors assigned to the function.
	/// </summary>
	private List<IBehavior> behaviors;

	/// <summary>
	/// Creates an instance of <see cref="BehaviorInvoker"/>.
	/// </summary>
	/// <param name="behaviors">List of behaviors to include in this invoker.</param>
	public BehaviorInvoker(IEnumerable<IBehavior>? behaviors = null)
	{
		this.behaviors = behaviors?.ToList()
			?? new();
	}

	public void AddBehaviors(params IEnumerable<IBehavior> behaviors)
	{
		this.behaviors.AddRange(behaviors);
	}

	/// <summary>
	/// Invoke behavior for a method with zero params returning void.
	/// </summary>
	public void InvokeActionBehavior()
	{
		InvokeSideEffects<Action>(
			action => action());

		InvokeActionBehaviors<Func<Exception>>(
			exceptionFactory => exceptionFactory());
	}

	/// <summary>
	/// Invoke behavior for a method with 1 param returning void.
	/// </summary>
	/// <typeparam name="Tin">Type of the 1st parameter accepted by the simulated method.</typeparam>
	public void InvokeActionBehavior<Tin>(
		Tin input)
	{
		InvokeSideEffects<Action<Tin>>(
			action => action(input));

		InvokeActionBehaviors<Func<Tin, Exception>>(
			exceptionFactory => exceptionFactory(input));
	}

	/// <summary>
	/// Invoke behavior for a method with 2 params returning void.
	/// </summary>
	/// <typeparam name="T1">Type of the 1st parameter accepted by the simulated method.</typeparam>
	/// <typeparam name="T2">Type of the 2nd parameter accepted by the simulated method.</typeparam>
	public void InvokeActionBehavior<T1, T2>(
		T1 p1, T2 p2)
	{
		InvokeSideEffects<Action<T1, T2>>(
			action => action(p1, p2));

		InvokeActionBehaviors<Func<T1, T2, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2));
	}

	/// <summary>
	/// Invoke behavior for a method with 3 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3>(
		T1 p1, T2 p2, T3 p3)
	{
		InvokeSideEffects<Action<T1, T2, T3>>(
			action => action(p1, p2, p3));

		InvokeActionBehaviors<Func<T1, T2, T3, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3));
	}

	/// <summary>
	/// Invoke behavior for a method with 4 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4>(
		T1 p1, T2 p2, T3 p3, T4 p4)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4>>(
			action => action(p1, p2, p3, p4));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4));
	}

	/// <summary>
	/// Invoke behavior for a method with 5 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5>>(
			action => action(p1, p2, p3, p4, p5));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5));
	}

	/// <summary>
	/// Invoke behavior for a method with 6 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6>>(
			action => action(p1, p2, p3, p4, p5, p6));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6));
	}

	/// <summary>
	/// Invoke behavior for a method with 7 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7>>(
			action => action(p1, p2, p3, p4, p5, p6, p7));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7));
	}

	/// <summary>
	/// Invoke behavior for a method with 8 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8));
	}

	/// <summary>
	/// Invoke behavior for a method with 9 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	/// <summary>
	/// Invoke behavior for a method with 10 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	/// <summary>
	/// Invoke behavior for a method with 11 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	/// <summary>
	/// Invoke behavior for a method with 12 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
	}

	/// <summary>
	/// Invoke behavior for a method with 13 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
	}

	/// <summary>
	/// Invoke behavior for a method with 14 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));
	}

	/// <summary>
	/// Invoke behavior for a method with 15 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));
	}

	/// <summary>
	/// Invoke behavior for a method with 16 params returning void.
	/// </summary>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));

		InvokeActionBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
	}

	/// <summary>
	/// Invoke behavior for a method with zero params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<Tout>()
	{
		InvokeSideEffects<Action>(action => action());

		// use the common invoker for Func with 0 params
		return InvokeFuncBehaviors<Func<Exception>, Func<Tout>, Tout>(
			exceptionFactory => exceptionFactory(),
			valueFactory => valueFactory());
	}

	/// <summary>
	/// Invoke behavior for a method with 1 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tin">Type of the parameter accepted by the simulated method.</typeparam>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<Tin, Tout>(Tin input)
	{
		InvokeSideEffects<Action<Tin>>(
			action => action(input));

		return InvokeFuncBehaviors<Func<Tin, Exception>, Func<Tin, Tout>, Tout>(
			exceptionFactory => exceptionFactory(input),
			valueFactory => valueFactory(input));
	}

	/// <summary>
	/// Invoke behavior for a method with 2 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="T1">Type of the 1st parameter accepted by the simulated method.</typeparam>
	/// <typeparam name="T2">Type of the 2nd parameter accepted by the simulated method.</typeparam>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, Tout>(T1 p1, T2 p2)
	{
		InvokeSideEffects<Action<T1, T2>>(
			action => action(p1, p2));

		return InvokeFuncBehaviors<Func<T1, T2, Exception>, Func<T1, T2, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2),
			valueFactory => valueFactory(p1, p2));
	}

	/// <summary>
	/// Invoke behavior for a method with 3 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, Tout>(T1 p1, T2 p2, T3 p3)
	{
		InvokeSideEffects<Action<T1, T2, T3>>(
			action => action(p1, p2, p3));

		return InvokeFuncBehaviors<Func<T1, T2, T3, Exception>, Func<T1, T2, T3, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3),
			valueFactory => valueFactory(p1, p2, p3));
	}

	/// <summary>
	/// Invoke behavior for a method with 4 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, Tout>(T1 p1, T2 p2, T3 p3, T4 p4)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4>>(
			action => action(p1, p2, p3, p4));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, Exception>, Func<T1, T2, T3, T4, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4),
			valueFactory => valueFactory(p1, p2, p3, p4));
	}

	/// <summary>
	/// Invoke behavior for a method with 5 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5>>(
			action => action(p1, p2, p3, p4, p5));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, Exception>, Func<T1, T2, T3, T4, T5, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5),
			valueFactory => valueFactory(p1, p2, p3, p4, p5));
	}

	/// <summary>
	/// Invoke behavior for a method with 6 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6>>(
			action => action(p1, p2, p3, p4, p5, p6));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, Exception>, Func<T1, T2, T3, T4, T5, T6, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6));
	}

	/// <summary>
	/// Invoke behavior for a method with 7 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7>>(
			action => action(p1, p2, p3, p4, p5, p6, p7));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7));
	}

	/// <summary>
	/// Invoke behavior for a method with 8 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8));
	}

	/// <summary>
	/// Invoke behavior for a method with 9 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	/// <summary>
	/// Invoke behavior for a method with 10 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	/// <summary>
	/// Invoke behavior for a method with 11 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	/// <summary>
	/// Invoke behavior for a method with 12 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
	}

	/// <summary>
	/// Invoke behavior for a method with 13 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
	}

	/// <summary>
	/// Invoke behavior for a method with 14 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));
	}

	/// <summary>
	/// Invoke behavior for a method with 15 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));
	}

	/// <summary>
	/// Invoke behavior for a method with 16 params returning values of type <see cref="{Tout}"/>.
	/// </summary>
	/// <typeparam name="Tout">Type of value returned by the method for which we invoke behaviors.</typeparam>
	public FuncReturnValue<Tout>? InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
	{
		InvokeSideEffects<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
			action => action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));

		return InvokeFuncBehaviors<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>, Tout>(
			exceptionFactory => exceptionFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16),
			valueFactory => valueFactory(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
	}
	
	/// <summary>
	/// Invokes all side-effects matching the provided action signature.
	/// </summary>
	/// <typeparam name="TAction">Defines the type of side-effect action to find and invoke</typeparam>
	/// <param name="invocation">Invocation providing parameter values to the side-effect action.</param>
	private void InvokeSideEffects<TAction>(Action<TAction> invocation)
		where TAction : Delegate
	{
		for(int idx = 0; idx < behaviors.Count; idx++)
		{
			var behavior = behaviors[idx];
			if (behavior is SideEffectBehavior<TAction> sideEffect)
			{
				var sideEffectAction = sideEffect.SideEffectAction;
				invocation(sideEffectAction);
			}
		}
	}

	private void InvokeActionBehaviors<TExceptionFactory>(
		Func<TExceptionFactory, Exception> exceptionFactoryInvocation)
		where TExceptionFactory : Delegate
	{
		// TODO: idx could probably start with this.lastUsedBehaviorIndex - check after making more unit tests
		for (int idx = 0; idx < behaviors.Count; idx++)
		{
			if (!CanApplyBehaviorAt(idx))
				continue;

			var behavior = behaviors[idx];

			if (behavior is ThrowBehavior<TExceptionFactory> throwBehavior)
			{
				this.lastUsedBehaviorIndex = idx;
				var exceptionFactory = throwBehavior.ExceptionFactory;
				var exception = exceptionFactoryInvocation(exceptionFactory);
				throw exception;
			}
		}
	}

	private FuncReturnValue<Tout>? InvokeFuncBehaviors<TExceptionFactory, TValueFactory, Tout>(
		Func<TExceptionFactory, Exception> exceptionFactoryInvocation,
		Func<TValueFactory, Tout> valueFactoryInvocation)
		where TExceptionFactory : Delegate
		where TValueFactory : Delegate
	{
		// TODO: idx could probably start with this.lastUsedBehaviorIndex - check after making more unit tests
		for (int idx = 0; idx < behaviors.Count; idx++)
		{
			if (!CanApplyBehaviorAt(idx))
				continue;

			var behavior = behaviors[idx];
			if (behavior is ThrowBehavior<TExceptionFactory> throwBehavior)
			{
				this.lastUsedBehaviorIndex = idx;
				var exceptionFactory = throwBehavior.ExceptionFactory;
				var exception = exceptionFactoryInvocation(exceptionFactory);
				throw exception;
			}
			else if (behavior is ReturnBehavior<TValueFactory> returnBehavior)
			{
				this.lastUsedBehaviorIndex = idx;
				var valueFactory = returnBehavior.ValueFactory;
				return (FuncReturnValue<Tout>)valueFactoryInvocation(valueFactory);
			}
		}

		// if we arrived here it means there was nothing returning and nothing throwing so far
		return null;
	}

	/// <summary>
	/// Returns true if the behavior at the specified index
	/// is not a side effect and can be applied now.
	/// </summary>
	/// <param name="index">Index of behavior to check.</param>
	private bool CanApplyBehaviorAt(int index)
	{
		if (index + 1 == this.behaviors.Count)
			// this is the last behavior - we repeat it
			return true;

		// side-effect behaviors are run separately
		if (this.behaviors[index] is IInvokeBehavior)
			return false;

		// only allow behaviors after the last used one
		return index > this.lastUsedBehaviorIndex;
	}
}
