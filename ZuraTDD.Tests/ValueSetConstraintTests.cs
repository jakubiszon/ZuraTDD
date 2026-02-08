using ZuraTDD;

namespace ZuraTDD.Tests;

[TestClass]
public class ValueSetConstraintTests
{
	[TestMethod]
	[DataRow(11, null)]
	[DataRow(int.MinValue, "")]
	[DataRow(0, "xxxx")]
	public void ValueSerConstraint_IntString_Tests(int intValue, string strValue)
	{
		var constraint = new ValueSetConstraint(
			new ValueConstraint<int>(),
			new ValueConstraint<string>());

		Assert.IsTrue(constraint.Matches([ intValue, strValue ]));
	}
}
