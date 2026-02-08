namespace ZuraTDD.Tests;

[TestClass]
public class RandomStuffTests
{
	private static int Length(params object[] items)
	{
		return items.Length;
	}

	private static int GenericLength<T>(params T[] items)
	{
		return items.Length;
	}

	/// <summary>
	/// The test illustrates how a single array could be misinterpreted
	/// as a set of values instead of a single value in an array.
	/// Using the 'params' keyword could lead to mistakes.
	/// </summary>
	[TestMethod]
	public void Length_ReceivingObjects()
	{
		object[] exampleItems = { 1, 2, 3 };
		int[] intItems = { 1, 2, 3 };

		Assert.AreEqual(2, Length(intItems, exampleItems));

		Assert.AreEqual(3, Length(exampleItems));
	}

	[TestMethod]
	public void Length_ReceivingStringArrays()
	{
		int[] exampleItems = { 1, 2, 3 };

		Assert.AreEqual(1, Length(exampleItems));

		Assert.AreEqual(1, GenericLength<object>(exampleItems));
	}
}
