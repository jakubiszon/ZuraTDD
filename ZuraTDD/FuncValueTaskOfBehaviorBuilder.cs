using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Marks a behavior-builder used for a function which returns a <see cref="ValueTask{T}" />.
/// </summary>
/// <typeparam name="Tout">Type of data returned in the valuetask.</typeparam>
public interface IValueTaskFuncBuilder<Tout>
	: IFuncBehaviorBuilder<ValueTask<Tout>>
{
}

public class FuncValueTaskOfBehaviorBuilder<Tout>
	: FuncBehaviorBuilder<Task<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, new([]), setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<Tin, Tout>
	: FuncBehaviorBuilder<Tin, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<Tin, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, Tout>
	: FuncBehaviorBuilder<T1, T2, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}

public class FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, ValueTask<Tout>>
	, IValueTaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncValueTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncValueTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> ThrowsFromValueTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<ValueTask<Tout>>>(() => new ValueTask<Tout>(Task.FromException<Tout>(exception)));
		this.Add(behavior);
		return this;
	}
}
