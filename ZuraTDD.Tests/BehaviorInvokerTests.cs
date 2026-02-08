namespace ZuraTDD.Tests;

/**
 * Tests verifying the logic and state management of the BehaviorInvoker class.
 */

[TestClass]
public partial class BehaviorInvokerTests
{
	[TestMethod]
	public void InvokeFuncBehavior_WithoutBehaviors_ReturnsNull()
	{
		// arrange
		var invoker = new BehaviorInvoker();

		// act - btw. for different return types one should have separare invokers
		//       it only works here because we do not have any behaviors added
		var intResult = invoker.InvokeFuncBehavior<int>();
		var doubleResult = invoker.InvokeFuncBehavior<double>();

		// assert
		Assert.IsNull(intResult);
		Assert.IsNull(doubleResult);
	}

	[TestMethod]
	public void InvokeFuncBehavior_CallsAllSideEffects()
	{
		// arrange
		bool sideEffectCalled_1 = false;
		bool sideEffectCalled_2 = false;

		var invoker = new BehaviorInvoker();
		invoker.AddBehaviors(
			new SideEffectBehavior<Action>(() => { sideEffectCalled_1 = true; }),
			new SideEffectBehavior<Action>(() => { sideEffectCalled_2 = true; })
		);

		// act
		invoker.InvokeFuncBehavior<int>();

		// assert
		Assert.IsTrue(sideEffectCalled_1);
		Assert.IsTrue(sideEffectCalled_2);
	}

	/// <summary>
	/// We setup 2 side effect and 2 returned values.
	/// We expect both side effects to be called on each call.
	/// We expect first call to return first value, second call to return second value
	/// and all subsequent calls to return the last setup.
	/// </summary>
	[TestMethod]
	public void InvokeFuncBehavior_RepeatsLastReturnValue()
	{
		// arrange
		int sideEffectCount_1 = 0;
		int sideEffectCount_2 = 0;

		var invoker = new BehaviorInvoker();
		invoker.AddBehaviors(
			new SideEffectBehavior<Action>(() => sideEffectCount_1++),
			new ReturnBehavior<Func<int>>(() => 11),
			new SideEffectBehavior<Action>(() => sideEffectCount_2++),
			new ReturnBehavior<Func<int>>(() => 33)
		);

		// act and assert - first call
		var firstResult = invoker.InvokeFuncBehavior<int>();
		Assert.IsNotNull(firstResult);
		Assert.AreEqual(11, firstResult.Value);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);

		// act and assert - second call
		var secondResult = invoker.InvokeFuncBehavior<int>();
		Assert.IsNotNull(secondResult);
		Assert.AreEqual(33, secondResult.Value);
		Assert.AreEqual(2, sideEffectCount_1);
		Assert.AreEqual(2, sideEffectCount_2);

		// act and assert - third call
		var thirdResult = invoker.InvokeFuncBehavior<int>();
		Assert.IsNotNull(thirdResult);
		Assert.AreEqual(33, thirdResult.Value);
		Assert.AreEqual(3, sideEffectCount_1);
		Assert.AreEqual(3, sideEffectCount_2);

		
		// act and assert - fourth call
		var fourthResult = invoker.InvokeFuncBehavior<int>();
		Assert.IsNotNull(fourthResult);
		Assert.AreEqual(33, fourthResult.Value);
		Assert.AreEqual(4, sideEffectCount_1);
		Assert.AreEqual(4, sideEffectCount_2);
	}

	/// <summary>
	/// We setup 2 side effect and 2 exceptions.
	/// We expect both side effects to be called on each call.
	/// We expect the first exception to be thrown on first call.
	/// On all later calls - the second exception is thrown.
	/// </summary>
	[TestMethod]
	public void InvokeFuncBehavior_ThrowsLastException()
	{
		// arrange
		int sideEffectCount_1 = 0;
		int sideEffectCount_2 = 0;

		var invoker = new BehaviorInvoker();
		invoker.AddBehaviors(
			new SideEffectBehavior<Action>(() => sideEffectCount_1++),
			new ThrowBehavior<Func<Exception>>(() => new Exception("first exception")),
			new SideEffectBehavior<Action>(() => sideEffectCount_2++),
			new ThrowBehavior<Func<Exception>>(() => new Exception("second exception"))
		);

		// act and assert - first call
		var exception1 = Assert.Throws<Exception>(() => invoker.InvokeFuncBehavior<int>());
		Assert.AreEqual("first exception", exception1.Message);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);

		// act and assert - second call
		var exception2 = Assert.Throws<Exception>(() => invoker.InvokeFuncBehavior<int>());
		Assert.AreEqual("second exception", exception2.Message);
		Assert.AreEqual(2, sideEffectCount_1);
		Assert.AreEqual(2, sideEffectCount_2);

		// act and assert - third call
		var exception3 = Assert.Throws<Exception>(() => invoker.InvokeFuncBehavior<int>());
		Assert.AreEqual("second exception", exception3.Message);
		Assert.AreEqual(3, sideEffectCount_1);
		Assert.AreEqual(3, sideEffectCount_2);

		
		// act and assert - fourth call
		var exception4 = Assert.Throws<Exception>(() => invoker.InvokeFuncBehavior<int>());
		Assert.AreEqual("second exception", exception4.Message);
		Assert.AreEqual(4, sideEffectCount_1);
		Assert.AreEqual(4, sideEffectCount_2);
	}

	[TestMethod]
	public void InvokeActionBehavior_0_WithoutBehaviors_DoesNotThrow()
	{
		// arrange
		var invoker = new BehaviorInvoker();

		// act and assert
		invoker.InvokeActionBehavior();
	}

	[TestMethod]
	public void InvokeActionBehavior_1_WithoutBehaviors_DoesNotThrow()
	{
		// arrange
		var invoker = new BehaviorInvoker();

		// act and assert
		invoker.InvokeActionBehavior(1);
	}
}
