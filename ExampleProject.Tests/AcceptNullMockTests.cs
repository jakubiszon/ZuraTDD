using ZuraTDD;

namespace ExampleProject.Tests;

/// <summary>
/// Tests matching <see langword="null"/> with <see cref="ValueConstraint{T}"/>.
/// </summary>
[TestClass]
public class AcceptNullMockTests
{
	[TestMethod]
	public void PassingNullAsValueConstraint_AcceptsAllValues()
	{
		var (setup, buildInstance, buildExpect) = new AcceptNullMock();
		var sideEffectCount1 = 0;
		var sideEffectCount2 = 0;
		var sideEffectCount3 = 0;

		setup.StringMethod()
			.Invokes(() => sideEffectCount1++);

		setup.StringMethod(null)
			.Invokes(() => sideEffectCount2++);

		setup.StringMethod(value: null)
			.Invokes(() => sideEffectCount3++);

		var sut = buildInstance();
		sut.StringMethod(null);
		sut.StringMethod("some value");

		Assert.AreEqual(2, sideEffectCount1);
		Assert.AreEqual(2, sideEffectCount2);
		Assert.AreEqual(2, sideEffectCount3);
	}

	[TestMethod]
	public void PassingNullAsValueToMatch_AcceptsNull()
	{
		var (setup, buildInstance, buildExpect) = new AcceptNullMock();
		var sideEffectCount1 = 0;
		var sideEffectCount2 = 0;
		var sideEffectCount3 = 0;
		var sideEffectCount4 = 0;

		setup.StringMethod(null)
			.Invokes(() => sideEffectCount1++);

		setup.StringMethod((string?)null)
			.Invokes(() => sideEffectCount2++);

		setup.StringMethod(new(s => s == null))
			.Invokes(() => sideEffectCount3++);

		setup.StringMethod(new((string?)null))
			.Invokes(() => sideEffectCount4++);

		var sut = buildInstance();
		sut.StringMethod(null);
		sut.StringMethod("some value");

		Assert.AreEqual(2, sideEffectCount1);
		Assert.AreEqual(1, sideEffectCount2);
		Assert.AreEqual(1, sideEffectCount3);
		Assert.AreEqual(1, sideEffectCount4);
	}
}
