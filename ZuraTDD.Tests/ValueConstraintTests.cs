namespace ZuraTDD.Tests;

[TestClass]
public class ValueConstraintTests
{
	[TestMethod]
	public void UnconstrainedInt_MatchesAnyInt()
	{
		var constraint = new ValueConstraint<int>();

		Assert.IsTrue(constraint.IsMatching(0));
		Assert.IsTrue(constraint.IsMatching(int.MinValue));
		Assert.IsTrue(constraint.IsMatching(int.MaxValue));
		Assert.IsTrue(constraint.IsMatching(1));
		Assert.IsTrue(constraint.IsMatching(777));
		Assert.IsTrue(constraint.IsMatching(326546));
	}

	[TestMethod]
	public void WhenWrongType_Throws()
	{
		var intConstraint = new ValueConstraint<int>();
		Assert.Throws<ArgumentException>(() => intConstraint.IsMatching("example"));

		var stringConstraint = new ValueConstraint<string>();
		Assert.Throws<ArgumentException>(() => stringConstraint.IsMatching(123));
	}

	[TestMethod]
	public void UnconstrainedNullable_AcceptsNull()
	{
		var stringConstraint = new ValueConstraint<string?>();
		Assert.IsTrue(stringConstraint.IsMatching(null));

		var intNullableConstraint = new ValueConstraint<int?>();
		Assert.IsTrue(intNullableConstraint.IsMatching(null));
	}

	[TestMethod]
	public void UnconstrainedNonNullableReferenceType_AcceptsNull()
	{
		var stringConstraint = new ValueConstraint<string>();

		#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.IsTrue(stringConstraint.IsMatching(null));
		#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[TestMethod]
	public void UnconstrainedValueType_AcceptsCompatibleValues()
	{
		var constraint = new ValueConstraint<int>();
		int? nullableValue = 11;

		Assert.IsTrue(constraint.IsMatching(nullableValue));

		object boxedValue = 123;
		Assert.IsTrue(constraint.IsMatching(boxedValue));
	}

	[TestMethod]
	public void ExactValueNullable_AcceptsNull()
	{
		var constraint = new ValueConstraint<int?>(exactValue: null);

		Assert.IsTrue(constraint.IsMatching(null));
		Assert.IsFalse(constraint.IsMatching(0));
		Assert.IsFalse(constraint.IsMatching(11));
	}

	[TestMethod]
	public void IntPredicate_AcceptsExpectedValues()
	{
		var constraint = new ValueConstraint<int?>(x => x > 1 && x < 5);

		Assert.IsFalse(constraint.IsMatching(null));
		Assert.IsFalse(constraint.IsMatching(0));
		Assert.IsFalse(constraint.IsMatching(1));
		Assert.IsTrue(constraint.IsMatching(2));
		Assert.IsTrue(constraint.IsMatching(3));
		Assert.IsTrue(constraint.IsMatching(4));
		Assert.IsFalse(constraint.IsMatching(5));
	}

	[TestMethod]
	public void StringPredicate_AcceptsExpectedValues()
	{
		var constraint = new ValueConstraint<string?>(x => x != null && x.StartsWith('x'));

		Assert.IsFalse(constraint.IsMatching(null));
		Assert.IsFalse(constraint.IsMatching("a"));
		Assert.IsTrue(constraint.IsMatching("x"));
		Assert.IsTrue(constraint.IsMatching("xa"));
		Assert.IsFalse(constraint.IsMatching("X"));
	}

	[TestMethod]
	public void GuidExactValue_AcceptsOnlyThatValue()
	{
		Guid expected = Guid.NewGuid();
		var constraint = new ValueConstraint<Guid>(exactValue: expected);

		Assert.IsTrue(constraint.IsMatching(expected));
		Assert.IsFalse(constraint.IsMatching(Guid.Empty));
		Assert.IsFalse(constraint.IsMatching(Guid.NewGuid()));

		string s = expected.ToString();
		Assert.IsTrue(constraint.IsMatching(Guid.Parse(s)));
	}
}
