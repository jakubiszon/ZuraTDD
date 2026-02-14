using ZuraTDD;
using static ExampleProject.Tests.ExampleValues;

namespace ExampleProject.Tests;

public partial class FuncServiceMockTests
{
	[TestMethod]
	public void F0_CallsReturns()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F0()
			.Returns(12345);

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F0());
	}

	[TestMethod]
	public void F1_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F1()
			.Returns((p1) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F1(V1));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F2_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F2()
			.Returns((p1, p2) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F2(V1, V2));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F3_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F3()
			.Returns((p1, p2, p3) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F3(V1, V2, V3));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F4_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F4()
			.Returns((p1, p2, p3, p4) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F4(V1, V2, V3, V4));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F5_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F5()
			.Returns((p1, p2, p3, p4, p5) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F5(V1, V2, V3, V4, V5));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F6_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F6()
			.Returns((p1, p2, p3, p4, p5, p6) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F6(V1, V2, V3, V4, V5, V6));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F7_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F7()
			.Returns((p1, p2, p3, p4, p5, p6, p7) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F7(V1, V2, V3, V4, V5, V6, V7));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F8_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F8()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F8(V1, V2, V3, V4, V5, V6, V7, V8));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F9_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F9()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
			{
				sideEffectCalled = true;
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				Assert.AreEqual(V9, p9);
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F9(V1, V2, V3, V4, V5, V6, V7, V8, V9));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F10_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F10()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F10(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F11_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F11()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F11(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F12_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F12()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F12(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F13_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F13()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F13(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F14_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F14()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F14(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F15_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F15()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F15(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15));
		Assert.IsTrue(sideEffectCalled);
	}

	[TestMethod]
	public void F16_CallsReturns()
	{
		var sideEffectCalled = false;
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F16()
			.Returns((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) =>
			{
				sideEffectCalled = true;
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
				return 12345;
			});

		var instance = buildInstance();
		Assert.AreEqual(12345, instance.F16(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16));
		Assert.IsTrue(sideEffectCalled);
	}
}
