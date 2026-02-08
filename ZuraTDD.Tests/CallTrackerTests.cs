using ZuraTDD;

using System.Reflection;

namespace ZuraTDD.Tests;

[TestClass]
public sealed class CallTrackerTests
{
	[TestMethod]
	public void ReceiveCall_CreatesData()
	{
		CallTracker callTracker = new CallTracker();
		MethodInfo receivingMethod = Example.ICustomerRepository_Methods.ListByInterests__string;

		Assert.AreEqual(0, callTracker.GetCallCount());

		callTracker.ReceiveCall(receivingMethod, []);
		Assert.AreEqual(1, callTracker.GetCallCount());

		callTracker.ReceiveCall(receivingMethod, []);
		Assert.AreEqual(2, callTracker.GetCallCount());

		callTracker.ReceiveCall(receivingMethod, []);
		Assert.AreEqual(3, callTracker.GetCallCount());
	}

	[TestMethod]
	public void GetCallCount_WithDelegate_ReturnsExpected()
	{
		CallTracker callTracker = new CallTracker();
		MethodInfo method1 = Example.ICustomerRepository_Methods.ListByInterests__string;
		MethodInfo method2 = Example.ICustomerRepository_Methods.ListByInterests__List_string;
		MethodInfo method3 = Example.ICustomerRepository_Methods.ListAll;

		Assert.AreEqual(0, callTracker.GetCallCount());

		callTracker.ReceiveCall(method1, []);
		callTracker.ReceiveCall(method2, []);
		callTracker.ReceiveCall(method2, []);

		Assert.AreEqual(1, callTracker.GetCallCount(method1));
		Assert.AreEqual(2, callTracker.GetCallCount(method2));
		Assert.AreEqual(0, callTracker.GetCallCount(method3));
	}

	[TestMethod]
	public void SeparateTrackes_KeepSeparateRecords()
	{
		ExampleTrackedObject obj1 = new ExampleTrackedObject();
		ExampleTrackedObject obj2 = new ExampleTrackedObject();

		obj1.ExampleAction(1);
		obj2.ExampleAction(12);
		obj2.ExampleAction(123);

		Assert.AreEqual(1, obj1.Tracker.GetCallCount(ExampleTrackedObject.ExampleAction_MethodInfo));
		Assert.AreEqual(2, obj2.Tracker.GetCallCount(ExampleTrackedObject.ExampleAction_MethodInfo));
	}
}
