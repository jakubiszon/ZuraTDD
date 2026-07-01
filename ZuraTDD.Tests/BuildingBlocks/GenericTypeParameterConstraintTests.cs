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
	public void PredicateCheckingInheritance_DoesNotMatchNonEnumerable()
	{
		var constraint = new GenericTypeParameterConstraint(
			t => typeof(IEnumerable<>).IsAssignableFrom(t) || 
				 (t.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(t.GetGenericTypeDefinition())));

		Assert.IsFalse(constraint.IsMatching(typeof(int)));
		Assert.IsFalse(constraint.IsMatching(typeof(string)));
	}

	[TestMethod]
	public void Any_MatchesAllTypes()
	{
		var constraint = GenericTypeParameters.Any();

		Assert.IsTrue(constraint.IsMatching(typeof(string)));
		Assert.IsTrue(constraint.IsMatching(typeof(int)));
		Assert.IsTrue(constraint.IsMatching(typeof(List<string>)));
		Assert.IsTrue(constraint.IsMatching(typeof(object)));
		Assert.IsTrue(constraint.IsMatching(typeof(DateTime)));
	}

	[TestMethod]
	public void Inherits_MatchesExactBaseType()
	{
		var constraint = GenericTypeParameters.Inherits<IEnumerable>();

		Assert.IsTrue(constraint.IsMatching(typeof(IEnumerable)));
	}

	[TestMethod]
	public void Inherits_MatchesDerivedTypes()
	{
		var constraint = GenericTypeParameters.Inherits<IComparable>();

		// string implements IComparable
		Assert.IsTrue(constraint.IsMatching(typeof(string)));

		// int implements IComparable
		Assert.IsTrue(constraint.IsMatching(typeof(int)));
	}

	[TestMethod]
	public void Inherits_DoesNotMatchUnrelatedTypes()
	{
		var constraint = GenericTypeParameters.Inherits<IEnumerable>();

		Assert.IsFalse(constraint.IsMatching(typeof(int)));
		Assert.IsFalse(constraint.IsMatching(typeof(DateTime)));
	}

	[TestMethod]
	public void Inherits_MatchesGenericImplementations()
	{
		var constraint = GenericTypeParameters.Inherits<IEnumerable>();

		Assert.IsTrue(constraint.IsMatching(typeof(List<int>)));
		Assert.IsTrue(constraint.IsMatching(typeof(List<string>)));
	}
}
