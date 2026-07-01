using System;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// Represents data defining a call which was tracked with <see cref="CallTracker" /> object.
/// </summary>
internal class CallRecord
{
	public ZuraMethodInfo CalledMethod { get; }

	public object?[] Arguments { get; }

	public Type[]? GenericArguments { get; } = [];

	public CallRecord(
		ZuraMethodInfo? calledMethod,
		object?[]? arguments,
		Type[]? genericArguments = null)
	{
		CalledMethod = calledMethod
			?? throw new ArgumentNullException(nameof(calledMethod));

		Arguments = arguments ?? [];
		GenericArguments = genericArguments;
	}
}
