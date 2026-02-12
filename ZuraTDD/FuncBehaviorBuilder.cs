using System;
using System.Reflection;

namespace ZuraTDD;

// these comments illustrate how parameters could be added automagically
public class FuncBehaviorBuilder</*func-type-params*/Tout>
	: BehaviorBuilder
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="methodInfo"></param>
	/// <param name="setupProcessor">Setup processor called when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, new([]), setupProcessor)
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="methodInfo"></param>
	/// <param name="setupProcessor">Setup processor called when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
		// TODO if this constructor was not called Constraints could be private to ValueSetConstraint

		if (valueSetConstraint.Constraints.Length > 0)
			throw new Exceptions.IncorrectConfiguration(
				$"Cannot pass value filters to FuncBehaviorBuilder for a method which takes no parameters");
	}

	/*if-params*/
	// invokes with action consuming the params
	/*if-end*/
	public FuncBehaviorBuilder</*func-type-params*/Tout> Invokes(
		Action/*action-type-params*/ action)
	{
		var behavior = new SideEffectBehavior<Action/*action-type-params*/>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder</*func-type-params*/Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func</*func-type-params*/Tout>>((/*param-values*/) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder</*func-type-params*/Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func</*func-type-params*/Exception>>((/*param-values*/) => exception);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<Tin, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<Tin, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<Tin>>(_ => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Invokes(
		Action<Tin> action)
	{
		var behavior = new SideEffectBehavior<Action<Tin>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<Tin, Tout>>(_ => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Returns(Func<Tin, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<Tin, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<Tin, Exception>>(_ => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Throws(Func<Tin, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<Tin, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}


public class FuncBehaviorBuilder<T1, T2, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2>>((p1, p2) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Invokes(
		Action<T1, T2> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, Tout>>((p1, p2) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Returns(Func<T1, T2, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, Exception>>((p1, p2) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Throws(Func<T1, T2, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3>>((p1, p2, p3) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Invokes(
		Action<T1, T2, T3> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, Tout>>((p1, p2, p3) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Returns(Func<T1, T2, T3, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, Exception>>((p1, p2, p3) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Throws(Func<T1, T2, T3, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4>>((p1, p2, p3, p4) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Invokes(
		Action<T1, T2, T3, T4> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, Tout>>((p1, p2, p3, p4) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Returns(Func<T1, T2, T3, T4, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, Exception>>((p1, p2, p3, p4) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Throws(Func<T1, T2, T3, T4, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5>>((p1, p2, p3, p4, p5) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Invokes(
		Action<T1, T2, T3, T4, T5> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, Tout>>((p1, p2, p3, p4, p5) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Returns(Func<T1, T2, T3, T4, T5, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, Exception>>((p1, p2, p3, p4, p5) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Throws(Func<T1, T2, T3, T4, T5, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6>>((p1, p2, p3, p4, p5, p6) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, Tout>>((p1, p2, p3, p4, p5, p6) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, Exception>>((p1, p2, p3, p4, p5, p6) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7>>((p1, p2, p3, p4, p5, p6, p7) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Tout>>((p1, p2, p3, p4, p5, p6, p7) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Exception>>((p1, p2, p3, p4, p5, p6, p7) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8>>((p1, p2, p3, p4, p5, p6, p7, p8) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>((p1, p2, p3, p4, p5, p6, p7, p8, p9) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}

public class FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>
	: BehaviorBuilder
{
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Invokes(
		Action action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) => action());
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Returns(Tout value)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) => value);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>>(valueFactory);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Throws(Exception exception)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>>((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) => exception);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Throws(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception> exceptionFactory)
	{
		var behavior = new ThrowBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>>(exceptionFactory);
		this.Add(behavior);
		return this;
	}
}
