using static ZuraTDD.Tests.ExampleValues;

namespace ZuraTDD.Tests;

public partial class BehaviorInvokerTests
{
	[TestMethod]
	public void InvokeFuncBehavior_1_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, object>>(
			(p1) =>
			{
				Assert.AreEqual(V1, p1);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, object>(
			V1);
	}

	[TestMethod]
	public void InvokeFuncBehavior_2_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, object>>(
			(p1, p2) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, object>(
			V1, V2);
	}

	[TestMethod]
	public void InvokeFuncBehavior_3_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, object>>(
			(p1, p2, p3) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, object>(
			V1, V2, V3);
	}

	[TestMethod]
	public void InvokeFuncBehavior_4_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, object>>(
			(p1, p2, p3, p4) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, object>(
			V1, V2, V3, V4);
	}

	[TestMethod]
	public void InvokeFuncBehavior_5_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, object>>(
			(p1, p2, p3, p4, p5) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, object>(
			V1, V2, V3, V4, V5);
	}

	[TestMethod]
	public void InvokeFuncBehavior_6_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, object>>(
			(p1, p2, p3, p4, p5, p6) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, object>
			(V1, V2, V3, V4, V5, V6);
	}

	[TestMethod]
	public void InvokeFuncBehavior_7_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, object>>(
			(p1, p2, p3, p4, p5, p6, p7) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7);
	}

	[TestMethod]
	public void InvokeFuncBehavior_8_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8);
	}

	[TestMethod]
	public void InvokeFuncBehavior_9_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9);
	}

	[TestMethod]
	public void InvokeFuncBehavior_10_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10);
	}

	[TestMethod]
	public void InvokeFuncBehavior_11_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11);
	}

	[TestMethod]
	public void InvokeFuncBehavior_12_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12);
	}

	[TestMethod]
	public void InvokeFuncBehavior_13_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13);
	}

	[TestMethod]
	public void InvokeFuncBehavior_14_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14);
	}

	[TestMethod]
	public void InvokeFuncBehavior_15_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15);
	}

	[TestMethod]
	public void InvokeFuncBehavior_16_ReturnBehavior_PassesParamValue()
	{
		// arrange
		var behavior = new ReturnBehavior<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>>(
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
				return new();
			});

		var invoker = new BehaviorInvoker([behavior]);

		// act and assert
		invoker.InvokeFuncBehavior<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, object>(
			V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16);
	}
}
