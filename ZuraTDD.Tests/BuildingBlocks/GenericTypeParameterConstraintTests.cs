using System.Collections;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD.Tests.BuildingBlocks;

[TestClass]
public class GenericTypeParameterConstraintTests
{
	[TestMethod]
	public void ExactType_MatchesGivenType()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(string));

		Assert.IsTrue(constraint.IsMatching(typeof(string)));
	}

	[TestMethod]
	public void ExactType_DoesNotMatchDifferentType()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(string));

		Assert.IsFalse(constraint.IsMatching(typeof(int)));
	}

	[TestMethod]
	public void ExactType_DoesNotMatchDerivedType()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(object));

		Assert.IsFalse(constraint.IsMatching(typeof(string)));
	}

	[TestMethod]
	public void CustomPredicate_MatchesWhenPredicateReturnsTrue()
	{
		var constraint = new GenericTypeParameterConstraint(t => t.IsValueType);

		Assert.IsTrue(constraint.IsMatching(typeof(int)));
		Assert.IsTrue(constraint.IsMatching(typeof(double)));
		Assert.IsTrue(constraint.IsMatching(typeof(DateTime)));
	}

	[TestMethod]
	public void CustomPredicate_DoesNotMatchWhenPredicateReturnsFalse()
	{
		var constraint = new GenericTypeParameterConstraint(t => t.IsValueType);

		Assert.IsFalse(constraint.IsMatching(typeof(string)));
		Assert.IsFalse(constraint.IsMatching(typeof(object)));
		Assert.IsFalse(constraint.IsMatching(typeof(List<int>)));
	}

	[TestMethod]
	public void GenericArgument_Any_MatchesAnyType()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(GenericArgument.AnyType));
		Assert.IsTrue(constraint.IsMatching(typeof(string)));
		Assert.IsTrue(constraint.IsMatching(typeof(int)));
		Assert.IsTrue(constraint.IsMatching(typeof(List<int>)));
		Assert.IsTrue(constraint.IsMatching(typeof(object)));
	}

	[TestMethod]
	public void GenericArgument_AnyStruct_MatchesValueTypes()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(GenericArgument.AnyValueType));
		Assert.IsTrue(constraint.IsMatching(typeof(int)));
		Assert.IsTrue(constraint.IsMatching(typeof(decimal)));
		Assert.IsTrue(constraint.IsMatching(typeof(char)));
		Assert.IsTrue(constraint.IsMatching(typeof(System.Reflection.MemberTypes)));
	}

	[TestMethod]
	public void GenericArgument_AnyStruct_DoesNotMatchReferenceTypes()
	{
		var constraint = new GenericTypeParameterConstraint(typeof(GenericArgument.AnyValueType));
		Assert.IsFalse(constraint.IsMatching(typeof(object)));
		Assert.IsFalse(constraint.IsMatching(typeof(string)));
		//Assert.IsFalse(constraint.IsMatching(typeof(char?)));
		Assert.IsFalse(constraint.IsMatching(typeof(System.Collections.ArrayList)));
	}
}
