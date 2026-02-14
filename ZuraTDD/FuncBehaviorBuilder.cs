using System;
using System.Reflection;

namespace ZuraTDD;

public class FuncBehaviorBuilder<Tout>
	: BehaviorBuilder
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, new([]), setupProcessor)
	{
	}

	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
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
}

public class FuncBehaviorBuilder<Tin, Tout>
	: BehaviorBuilder
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<Tin, Tout> Invokes(
		Action<Tin> action)
	{
		var behavior = new SideEffectBehavior<Action<Tin>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<Tin, Tout> Returns(Func<Tin, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<Tin, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Invokes(
		Action<T1, T2> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, Tout> Returns(Func<T1, T2, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Invokes(
		Action<T1, T2, T3> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, Tout> Returns(Func<T1, T2, T3, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Invokes(
		Action<T1, T2, T3, T4> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, Tout> Returns(Func<T1, T2, T3, T4, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Invokes(
		Action<T1, T2, T3, T4, T5> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, Tout> Returns(Func<T1, T2, T3, T4, T5, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>>(valueFactory);
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
	, IFuncBehaviorBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Invokes(
		Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
	{
		var behavior = new SideEffectBehavior<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(action);
		this.Add(behavior);
		return this;
	}

	public FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> Returns(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> valueFactory)
	{
		var behavior = new ReturnBehavior<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>>(valueFactory);
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
