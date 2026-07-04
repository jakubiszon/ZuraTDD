using static ZuraTDD.Tests.ExampleValues;

namespace ZuraTDD.Tests;

/**
 * Tests for verifying that the correct parameter values are passed to the side effect behaviors
 * for all 16 parametrised overloads of InvokeFuncBehavior.
 */

public partial class BehaviorInvokerTests
{
	[TestMethod]
	public void InvokeFuncBehavior_0_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action>(
			() =>
			{
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<object>();

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_1_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int>>(
			(p1) =>
			{
				Assert.AreEqual(V1, p1);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, object>(
			V1);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_2_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int>>(
			(p1, p2) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, object>(
			V1, V2);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_3_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int>>(
			(p1, p2, p3) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, object>(
			V1, V2, V3);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_4_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int>>(
			(p1, p2, p3, p4) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, object>(
			V1, V2, V3, V4);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_5_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int>>(
			(p1, p2, p3, p4, p5) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, object>(
			V1, V2, V3, V4, V5);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_6_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_7_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_8_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_9_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_10_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_11_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_12_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				Assert.AreEqual(V12, p12);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_13_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				Assert.AreEqual(V12, p12);
				Assert.AreEqual(V13, p13);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_14_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				Assert.AreEqual(V12, p12);
				Assert.AreEqual(V13, p13);
				Assert.AreEqual(V14, p14);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_15_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				Assert.AreEqual(V12, p12);
				Assert.AreEqual(V13, p13);
				Assert.AreEqual(V14, p14);
				Assert.AreEqual(V15, p15);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15);

		Assert.IsTrue(sideEffectWasCalled);
	}

	[TestMethod]
	public void InvokeFuncBehavior_16_WithSideEffect_PassesParamValue()
	{
		// arrange
		var sideEffectWasCalled = false;
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				Assert.AreEqual(V10, p10);
				Assert.AreEqual(V11, p11);
				Assert.AreEqual(V12, p12);
				Assert.AreEqual(V13, p13);
				Assert.AreEqual(V14, p14);
				Assert.AreEqual(V15, p15);
				Assert.AreEqual(V16, p16);
				sideEffectWasCalled = true;
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16);

		Assert.IsTrue(sideEffectWasCalled);
	}
}
