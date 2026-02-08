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
