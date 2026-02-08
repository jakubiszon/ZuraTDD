using System;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// Represents data defining a call which was tracked with <see cref="CallTracker" /> object.
/// </summary>
internal class CallRecord
{
	public MethodInfo CalledMethod { get; }

	public object?[] Arguments { get; }

	public CallRecord(
		MethodInfo? calledMethod,
		object?[]? arguments)
	{
		CalledMethod = calledMethod
			?? throw new ArgumentNullException(nameof(calledMethod));

		Arguments = arguments ?? [];
	}
}
