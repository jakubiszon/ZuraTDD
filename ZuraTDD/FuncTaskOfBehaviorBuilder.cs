using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Marks a behavior-builder used for a function which returns a <see cref="Task{T}" />.
/// </summary>
/// <typeparam name="Tout">Type of data returned in the task.</typeparam>
public interface ITaskFuncBuilder<Tout>
	: IFuncBehaviorBuilder<Task<Tout>>
{
}

public class FuncTaskOfBehaviorBuilder<Tout>
	: FuncBehaviorBuilder<Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, new([]), setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<Tin, Tout>
	: FuncBehaviorBuilder<Tin, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<Tin, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, Tout>
	: FuncBehaviorBuilder<T1, T2, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}

public class FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout>
	: FuncBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<Tout>>
	, ITaskFuncBuilder<Tout>
{
	/// <param name="methodInfo">Identifies the method which is being set up.</param>
	/// <param name="valueSetConstraint">Constraints matching values passed to the method.</param>
	/// <param name="setupProcessor">Setup processor used when <see cref="BehaviorBuilder.ToBehaviorSetup" /> is called.</param>
	public FuncTaskOfBehaviorBuilder(
		MethodInfo methodInfo,
		ValueSetConstraint valueSetConstraint,
		IBehaviorSetupProcessor setupProcessor)
		: base(methodInfo, valueSetConstraint, setupProcessor)
	{
	}

	public FuncTaskOfBehaviorBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Tout> ThrowsFromTask(
		Exception exception)
	{
		var behavior = new ReturnBehavior<Func<Task<Tout>>>(() => Task.FromException<Tout>(exception));
		this.Add(behavior);
		return this;
	}
}
