using ZuraTDD.BuildingBlocks;

namespace ZuraTDD.Tests.BuildingBlocks;

[TestClass]
public class GenericTypeParameterSetConstraintTests
{
	[TestMethod]
	public void EmptyConstraint_MatchesEmptyTypes()
	{
		var constraint = new GenericTypeParameterSetConstraint();

		Assert.IsTrue(constraint.Matches([]));
	}

	[TestMethod]
	public void EmptyConstraint_DoesNotMatchNonEmptyTypes()
	{
		var constraint = new GenericTypeParameterSetConstraint();

		Assert.IsFalse(constraint.Matches([typeof(string)]));
		Assert.IsFalse(constraint.Matches([typeof(int), typeof(string)]));
	}

	[TestMethod]
	public void SingleExactTypeConstraint_MatchesExpectedType()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)));

		Assert.IsTrue(constraint.Matches([typeof(string)]));
	}

	[TestMethod]
	public void SingleExactTypeConstraint_DoesNotMatchDifferentType()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)));

		Assert.IsFalse(constraint.Matches([typeof(int)]));
	}

	[TestMethod]
	public void SingleExactTypeConstraint_DoesNotMatchMultipleTypes()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)));

		Assert.IsFalse(constraint.Matches([typeof(string), typeof(int)]));
	}

	[TestMethod]
	public void MultipleExactTypeConstraints_MatchesAllTypesInOrder()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)),
			new GenericTypeParameterConstraint(typeof(int)),
			new GenericTypeParameterConstraint(typeof(bool)));

		Assert.IsTrue(constraint.Matches([typeof(string), typeof(int), typeof(bool)]));
	}

	[TestMethod]
	public void MultipleExactTypeConstraints_DoesNotMatchIfOrderIsWrong()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)),
			new GenericTypeParameterConstraint(typeof(int)));

		Assert.IsFalse(constraint.Matches([typeof(int), typeof(string)]));
	}

	[TestMethod]
	public void MultipleExactTypeConstraints_DoesNotMatchIfCountDiffers()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			new GenericTypeParameterConstraint(typeof(string)),
			new GenericTypeParameterConstraint(typeof(int)));

		Assert.IsFalse(constraint.Matches([typeof(string)]));
		Assert.IsFalse(constraint.Matches([typeof(string), typeof(int), typeof(bool)]));
	}

	[TestMethod]
	public void AnyConstraint_MatchesAnyType()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			GenericTypeParameters.Any());

		Assert.IsTrue(constraint.Matches([typeof(string)]));
		Assert.IsTrue(constraint.Matches([typeof(int)]));
		Assert.IsTrue(constraint.Matches([typeof(List<string>)]));
	}

	[TestMethod]
	public void MixedConstraints_MatchesWhenAllSatisfied()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			GenericTypeParameters.Any(),
			new GenericTypeParameterConstraint(typeof(string)));

		Assert.IsTrue(constraint.Matches([typeof(int), typeof(string)]));
		Assert.IsTrue(constraint.Matches([typeof(List<int>), typeof(string)]));
	}

	[TestMethod]
	public void MixedConstraints_DoesNotMatchIfAnyConstraintFails()
	{
		var constraint = new GenericTypeParameterSetConstraint(
			GenericTypeParameters.Any(),
			new GenericTypeParameterConstraint(typeof(string)));

		Assert.IsFalse(constraint.Matches([typeof(int), typeof(int)]));
		Assert.IsFalse(constraint.Matches([typeof(string), typeof(int)]));
	}
}
