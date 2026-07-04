using System;
using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// An object used to map mocked-object methods to their behaviors
/// and invoke those behaviors when the methods are called.
/// </summary>
public class BehaviorSetupRunner
{
	/// <summary>
	/// Maps method delegates to their behavior setups.
	/// </summary>
	private readonly Dictionary<ZuraMethodInfo, List<BehaviorSetup>> configuredSetups;

	public BehaviorSetupRunner()
	{
		this.configuredSetups = [];
	}

	public BehaviorSetupRunner(IEnumerable<BehaviorSetup> behaviorSetups)
	{
		this.configuredSetups = [];
		if (behaviorSetups != null)
		{
			foreach (var setup in behaviorSetups)
			{
				this.Add(setup);
			}
		}
	}

	public void Add(BehaviorSetup behaviorSetup)
	{
		if (!this.configuredSetups.ContainsKey(behaviorSetup.Method))
		{
			this.configuredSetups[behaviorSetup.Method] = [];
		}

		this.configuredSetups[behaviorSetup.Method].Add(behaviorSetup);
	}

	/// <summary>
	/// Invoke behavior for the specified method with zero params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior(
		ZuraMethodInfo method,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior());
	}

	/// <summary>
	/// Invoke behavior for the specified method with 1 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<Tin>(
		ZuraMethodInfo method,
		Tin input,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[input],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(input));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 2 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2>(
		ZuraMethodInfo method,
		T1 p1, T2 p2,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 3 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 4 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 5 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 6 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 7 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 8 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 9 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 10 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 11 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 12 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 13 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 14 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 15 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 16 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16,
		Type[]? genericParameterTypes)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16],
			genericParameterTypes,
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
	}

	private void InvokeActionBehaviorInternal(
		ZuraMethodInfo method,
		object?[] matcherParameters,
		Type[]? genericParameterTypes,
		Action<BehaviorInvoker> invokerAction)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches(matcherParameters, genericParameterTypes))
				continue;

			invokerAction(behaviorSetup.BehaviorInvoker);
		}
	}

	/// <summary>
	/// Invoke behavior for the specified method with zero params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<Tout>(
		ZuraMethodInfo method,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<Tout>();
			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 1 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, Tout>(
		ZuraMethodInfo method,
		T1 p1,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, Tout>(
				p1);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 3 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, Tout>(
				p1, p2);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 3 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, Tout>(
				p1, p2, p3);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 4 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, Tout>(
				p1, p2, p3, p4);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 5 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, Tout>(
				p1, p2, p3, p4, p5);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 6 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, Tout>(
				p1, p2, p3, p4, p5, p6);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 7 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, Tout>(
				p1, p2, p3, p4, p5, p6, p7);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 8 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 9 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 10 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 11 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 12 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 13 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 14 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 15 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}

	/// <summary>
	/// Invoke behavior for the specified method with 16 params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>(
		ZuraMethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16,
		Type[]? genericParameterTypes,
		Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16], genericParameterTypes))
				continue;

			// return result found in the first matching setup
			var result = behaviorSetup.BehaviorInvoker.InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>(
				p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);

			if(result != null)
				return result.Value;
		}

		return defaultResult;
	}
}
