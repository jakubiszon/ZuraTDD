using static ZuraTDD.Tests.ExampleValues;

namespace ZuraTDD.Tests;

/**
 * Tests for verifying that the correct parameter values are passed to exception factory functions
 * for all 16 parametrised overloads of InvokeActionBehavior.
 */

public partial class BehaviorInvokerTests
{
	[TestMethod]
	public void InvokeActionBehavior_1_WithThrow_PassesParamValue()
	{
		// arrange
		var behavior = new ThrowBehavior<Func<int, Exception>>(
			(p1) =>
			{
				Assert.AreEqual(V1, p1);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, object>(
			V1));
	}

	[TestMethod]
	public void InvokeActionBehavior_2_WithThrow_PassesParamValue()
	{
		// arrange
		var behavior = new ThrowBehavior<Func<int, int, Exception>>(
			(p1, p2) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, object>(
			V1, V2));
	}

	[TestMethod]
	public void InvokeActionBehavior_3_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, Exception>>(
			(p1, p2, p3) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, object>(
			V1, V2, V3));
	}

	[TestMethod]
	public void InvokeActionBehavior_4_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, Exception>>(
			(p1, p2, p3, p4) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, object>(
			V1, V2, V3, V4));
	}

	[TestMethod]
	public void InvokeActionBehavior_5_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, Exception>>(
			(p1, p2, p3, p4, p5) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, object>(
			V1, V2, V3, V4, V5));
	}

	[TestMethod]
	public void InvokeActionBehavior_6_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, Exception>>(
			(p1, p2, p3, p4, p5, p6) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6));
	}

	[TestMethod]
	public void InvokeActionBehavior_7_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, Exception>>(
			(p1, p2, p3, p4, p5, p6, p7) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7));
	}

	[TestMethod]
	public void InvokeActionBehavior_8_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8));
	}

	[TestMethod]
	public void InvokeActionBehavior_9_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9));
	}

	[TestMethod]
	public void InvokeActionBehavior_10_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10));
	}

	[TestMethod]
	public void InvokeActionBehavior_11_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11));
	}

	[TestMethod]
	public void InvokeActionBehavior_12_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, object>(
				V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12));
	}

	[TestMethod]
	public void InvokeActionBehavior_13_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13));
	}

	[TestMethod]
	public void InvokeActionBehavior_14_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14));
	}

	[TestMethod]
	public void InvokeActionBehavior_15_WithThrow_PassesParamValue()
	{
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15));
	}

	[TestMethod]
	public void InvokeActionBehavior_16_WithThrow_PassesParamValue()
	{
		// arrange
		var behavior = new ThrowBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Exception>>(
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
				return new TestException();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		Assert.Throws<TestException>(() => invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16));
	}
}
