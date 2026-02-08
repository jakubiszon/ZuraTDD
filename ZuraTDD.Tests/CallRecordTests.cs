using System.Reflection;

namespace ZuraTDD.Tests;

[TestClass]
public class CallRecordTests
{
	[TestMethod]
	public void Constructor_Throws_WhenCalledMethodIsNull()
	{
		// arrange
		MethodInfo? calledMethod = null;

		object?[] arguments = [];

		// act & assert
		Assert.Throws<ArgumentNullException>(() =>
		{
			var record = new CallRecord(
				calledMethod!,
				arguments);
		});
	}

	[TestMethod]
	public void Constructor_SetsProperties()
	{
		// arrange
		var calledMethod = typeof(string).GetMethod("Substring", new[] { typeof(int) })!;
		object?[] arguments = [ 5 ];

		// act
		var record = new CallRecord(
			calledMethod,
			arguments);

		// assert
		Assert.AreEqual(calledMethod, record.CalledMethod);
		Assert.AreEqual(arguments, record.Arguments);
	}

	[TestMethod]
	public void Constructor_AllowsNullArgumentsArray()
	{
		// arrange
		var calledMethod = typeof(string).GetMethod("Substring", new[] { typeof(int) })!;
		object?[]? arguments = null;

		// act
		var record = new CallRecord(
			calledMethod,
			arguments);

		// assert
		Assert.IsNotNull(record.Arguments);
		Assert.AreEqual(0, record.Arguments.Length);
	}
}
