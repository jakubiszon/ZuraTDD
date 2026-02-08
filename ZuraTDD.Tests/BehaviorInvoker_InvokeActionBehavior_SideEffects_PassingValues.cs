using static ZuraTDD.Tests.ExampleValues;

namespace ZuraTDD.Tests;

/**
 * Tests for verifying that the correct parameter values are passed to the side effect behaviors
 * for all 16 parametrised overloads of InvokeActionBehavior.
 */

public partial class BehaviorInvokerTests
{
	[TestMethod]
	public void InvokeActionBehavior_1_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int>>(
			input => Assert.AreEqual(V1, input));

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(V1);
	}

	[TestMethod]
	public void InvokeActionBehavior_2_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int, int>>(
			(p1, p2) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2);
	}

	[TestMethod]
	public void InvokeActionBehavior_3_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int, int, int>>(
			(p1, p2, p3) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3);
	}

	[TestMethod]
	public void InvokeActionBehavior_4_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int, int, int, int>>(
			(p1, p2, p3, p4) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4);
	}

	[TestMethod]
	public void InvokeActionBehavior_5_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int>>(
			(p1, p2, p3, p4, p5) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5);
	}

	[TestMethod]
	public void InvokeActionBehavior_6_WithSideEffect_PassesParamValue()
	{
		// arrange
		var behavior = new SideEffectBehavior<Action<int, int, int, int, int, int>>(
			(p1, p2, p3, p4, p5, p6) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6);
	}

	[TestMethod]
	public void InvokeActionBehavior_7_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7);
	}

	[TestMethod]
	public void InvokeActionBehavior_8_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8);
	}

	[TestMethod]
	public void InvokeActionBehavior_9_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9);
	}

	[TestMethod]
	public void InvokeActionBehavior_10_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10);
	}

	[TestMethod]
	public void InvokeActionBehavior_11_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11);
	}

	[TestMethod]
	public void InvokeActionBehavior_12_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12);
	}

	[TestMethod]
	public void InvokeActionBehavior_13_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13);
	}

	[TestMethod]
	public void InvokeActionBehavior_14_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14);
	}

	[TestMethod]
	public void InvokeActionBehavior_15_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15);
	}

	[TestMethod]
	public void InvokeActionBehavior_16_WithSideEffect_PassesParamValue()
	{
		// arrange
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
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeActionBehavior(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16);
	}
}
