using System;
using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

// TODO: add type param documentation
// TODO: add method param documentation
// TODO: expand generic params up to 16 - as the limit defined in Func and Action delegates

/// <summary>
/// An object used to map service methods to their behaviors
/// and invoke those behaviors when the methods are called.
/// </summary>
public class BehaviorSetupRunner
{
	/// <summary>
	/// Maps method delegates to their behavior setups.
	/// </summary>
	private Dictionary<MethodInfo, List<BehaviorSetup>> configuredSetups;

	public BehaviorSetupRunner()
	{
		this.configuredSetups = new();
	}

	public BehaviorSetupRunner(IEnumerable<BehaviorSetup> behaviorSetups)
	{
		this.configuredSetups = new();
		foreach(var setup in behaviorSetups)
		{
			this.Add(setup);
		}
	}

	public void Add(BehaviorSetup behaviorSetup)
	{
		if (!this.configuredSetups.ContainsKey(behaviorSetup.Method))
		{
			this.configuredSetups[behaviorSetup.Method] = new List<BehaviorSetup>();
		}

		this.configuredSetups[behaviorSetup.Method].Add(behaviorSetup);
	}

	/// <summary>
	/// Invoke behavior for the specified method with zero params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior(
		MethodInfo method)
	{
		InvokeActionBehaviorInternal(
			method,
			[],
			invoker => invoker.InvokeActionBehavior());
	}

	/// <summary>
	/// Invoke behavior for the specified method with 1 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<Tin>(
		MethodInfo method,
		Tin input)
	{
		InvokeActionBehaviorInternal(
			method,
			[input],
			invoker => invoker.InvokeActionBehavior(input));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 2 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2>(
		MethodInfo method,
		T1 p1, T2 p2)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2],
			invoker => invoker.InvokeActionBehavior(p1, p2));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 3 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 4 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 5 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 6 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 7 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 8 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 9 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 10 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 11 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 12 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 13 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 14 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 15 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));
	}

	/// <summary>
	/// Invoke behavior for the specified method with 16 params returning void.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public void InvokeActionBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
		MethodInfo method,
		T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
	{
		InvokeActionBehaviorInternal(
			method,
			[p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16],
			invoker => invoker.InvokeActionBehavior(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
	}

	private void InvokeActionBehaviorInternal(
		MethodInfo method,
		object?[] matcherParameters,
		Action<BehaviorInvoker> invokerAction)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches(matcherParameters))
				continue;

			invokerAction(behaviorSetup.BehaviorInvoker);
		}
	}

	/// <summary>
	/// Invoke behavior for the specified method with zero params returning <see cref="{Tout}" />.
	/// </summary>
	/// <param name="method">Method for which behaviors will be invoked.</param>
	public Tout InvokeFuncBehavior<Tout>(MethodInfo method, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
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
	public Tout InvokeFuncBehavior<T1, Tout>(MethodInfo method, T1 p1, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1]))
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
	public Tout InvokeFuncBehavior<T1, T2, Tout>(MethodInfo method, T1 p1, T2 p2, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15]))
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
	public Tout InvokeFuncBehavior<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>(MethodInfo method, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, Tout defaultResult)
	{
		if (!this.configuredSetups.ContainsKey(method))
			return defaultResult;

		foreach(var behaviorSetup in this.configuredSetups[method])
		{
			if (!behaviorSetup.ValueSetConstraint.Matches([p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16]))
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
