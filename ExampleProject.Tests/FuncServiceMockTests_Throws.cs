using static ExampleProject.Tests.ExampleValues;

namespace ExampleProject.Tests;

public partial class FuncServiceMockTests
{
	[TestMethod]
	public void F0_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F0()
			.Throws(new TestException());

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F0());
	}

	[TestMethod]
	public void F1_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F1()
			.Throws((p1) =>
			{
				Assert.AreEqual(V1, p1);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F1(V1));
	}

	[TestMethod]
	public void F2_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F2()
			.Throws((p1, p2) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F2(V1, V2));
	}

	[TestMethod]
	public void F3_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F3()
			.Throws((p1, p2, p3) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F3(V1, V2, V3));
	}

	[TestMethod]
	public void F4_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F4()
			.Throws((p1, p2, p3, p4) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F4(V1, V2, V3, V4));
	}

	[TestMethod]
	public void F5_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F5()
			.Throws((p1, p2, p3, p4, p5) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F5(V1, V2, V3, V4, V5));
	}

	[TestMethod]
	public void F6_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F6()
			.Throws((p1, p2, p3, p4, p5, p6) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F6(V1, V2, V3, V4, V5, V6));
	}

	[TestMethod]
	public void F7_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F7()
			.Throws((p1, p2, p3, p4, p5, p6, p7) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F7(V1, V2, V3, V4, V5, V6, V7));
	}

	[TestMethod]
	public void F8_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F8()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8) =>
			{
				Assert.AreEqual(V1, p1);
				Assert.AreEqual(V2, p2);
				Assert.AreEqual(V3, p3);
				Assert.AreEqual(V4, p4);
				Assert.AreEqual(V5, p5);
				Assert.AreEqual(V6, p6);
				Assert.AreEqual(V7, p7);
				Assert.AreEqual(V8, p8);
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F8(V1, V2, V3, V4, V5, V6, V7, V8));
	}

	[TestMethod]
	public void F9_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F9()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F9(V1, V2, V3, V4, V5, V6, V7, V8, V9));
	}

	[TestMethod]
	public void F10_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F10()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F10(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10));
	}

	[TestMethod]
	public void F11_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F11()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F11(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11));
	}

	[TestMethod]
	public void F12_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F12()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F12(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12));
	}

	[TestMethod]
	public void F13_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F13()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F13(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13));
	}

	[TestMethod]
	public void F14_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F14()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F14(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14));
	}

	[TestMethod]
	public void F15_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F15()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F15(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15));
	}

	[TestMethod]
	public void F16_CallsThrows()
	{
		var (setup, buildInstance, buildExpect) = new FuncServiceMock();

		setup.F16()
			.Throws((p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) =>
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
				throw new TestException();
			});

		var instance = buildInstance();
		Assert.Throws<TestException>(() => instance.F16(V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15, V16));
	}
}
