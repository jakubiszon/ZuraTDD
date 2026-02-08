using System;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Represents a method call on the tested object.
/// </summary>
public class TestedMethodCall
{
	private readonly Func<object, Delegate> methodLocator;
	private readonly object?[] parameters;

	public TestedMethodCall(
		Func<object, Delegate> methodLocator,
		object?[] parameters)
	{
		this.methodLocator = methodLocator;
		this.parameters = parameters;
	}

	public Task<object?> Call(object testSubject)
	{
		var method = this.methodLocator(testSubject);

		#pragma warning disable CS8604 // Possible null reference argument.
		var result = method.DynamicInvoke(this.parameters);
		#pragma warning restore CS8604 // Possible null reference argument.

		return result is Task task
			? HandleTaskResultAsync(task)
			: Task.FromResult<object?>(result);
	}

	private static async Task<object?> HandleTaskResultAsync(Task task)
	{
		// Get the Task's generic type to check if it has a Result property
		var taskType = task.GetType();
	
		// Check if this is a Task<T> (not just Task)
		if (taskType.IsGenericType && taskType.GetGenericTypeDefinition() == typeof(Task<>))
		{
			// Await the task and extract the Result property
			await task.ConfigureAwait(false);
			var resultProperty = taskType.GetProperty("Result");
			return resultProperty?.GetValue(task) ?? null!;
		}
		else
		{
			// It's a non-generic Task - just await it and return null
			await task.ConfigureAwait(false);
			return null;
		}
	}
}
