using System;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// Behavior builder for void methods with zero input parameters.
/// </summary>
public class ActionBehaviorBuilder
	: BehaviorBuilder
{
	/// <param name="methodInfo"></param>
	/// <param name="setupProcessor">Setup processor called when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, new([]), setupProcessor)
	{
	}

	public ActionBehaviorBuilder Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<Exception>>(() => exception);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 1 input parameter.
/// </summary>
public class ActionBehaviorBuilder<Tin>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<Tin> Invokes(
		Action<Tin> action)
	{
		var behavior = new SideEffectBehavior<Action<Tin>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<Tin> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<Tin, Exception>>(_ => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<Tin> Throws(Func<Tin, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<Tin, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}


/// <summary>
/// Behavior builder for void methods with 2 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2> Invokes(
		Action<T1, T2> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, Exception>>((p1, p2) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2> Throws(Func<T1, T2, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 3 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3> Invokes(
		Action<T1, T2, T3> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, Exception>>((p1, p2, p3) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3> Throws(Func<T1, T2, T3, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 4 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4> Invokes(
		Action<T1, T2, T3, T4> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, Exception>>((p1, p2, p3, p4) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4> Throws(Func<T1, T2, T3, T4, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 5 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5> Invokes(
		Action<T1, T2, T3, T4, T5> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, Exception>>((p1, p2, p3, p4, p5) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5> Throws(Func<T1, T2, T3, T4, T5, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 6 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6> Invokes(
		Action<T1, T2, T3, T4, T5, T6> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, Exception>>((p1, p2, p3, p4, p5, p6) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6> Throws(Func<T1, T2, T3, T4, T5, T6, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 7 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Exception>>((p1, p2, p3, p4, p5, p6, p7) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7> Throws(Func<T1, T2, T3, T4, T5, T6, T7, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 8 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 9 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 10 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 11 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 12 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 13 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 14 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 15 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

/// <summary>
/// Behavior builder for void methods with 16 input parameters.
/// </summary>
public class ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
	: BehaviorBuilder
{
	public ActionBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(action);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) => exception);
		this.Add(behavior);
		return this;
	}

	public ActionBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}
