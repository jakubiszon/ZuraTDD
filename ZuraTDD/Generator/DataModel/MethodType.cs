using System.Threading.Tasks;

namespace ZuraTDD.Generator.DataModel;

internal enum MethodType
{
	/// <summary>
	/// The method returns nothing (void).
	/// </summary>
	Void,

	/// <summary>
	/// The method returns a value which is not awaitable.
	/// </summary>
	Value,

	/// <summary>
	/// The method returns a <see cref="System.Threading.Tasks.Task">Task</see>.
	/// </summary>
	Task,

	/// <summary>
	/// The method returns a <see cref="Task{T}" />.
	/// </summary>
	TaskOfT,

	/// <summary>
	/// The method returns a <see cref="System.Threading.Tasks.ValueTask">ValueTask</see>.
	/// </summary>
	ValueTask,

	/// <summary>
	/// The method returns a <see cref="ValueTask{T}" />.
	/// </summary>
	ValueTaskOfT,
}
