using ZuraTDD;
using System.Reflection;

namespace ZuraTDD.Tests;

internal class ExampleTrackedObject
{
	public static MethodInfo ExampleAction_MethodInfo = typeof(ExampleTrackedObject)
		.GetMethod(nameof(ExampleAction))!;

	public CallTracker Tracker { get; }

	public ExampleTrackedObject()
	{
		this.Tracker = new();
	}

	public void ExampleAction(int value)
	{
		this.Tracker.ReceiveCall(ExampleAction_MethodInfo, [value]);
	}
}
