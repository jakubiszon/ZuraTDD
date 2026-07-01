using ZuraTDD.Exceptions;
using System;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// A call to a specific method and with specific value constraints
/// expected to be found in a <see cref="CallTracker"/>.
/// </summary>
public class ExpectedMethodCall
{
	private ZuraMethodInfo method;
	private ValueSetConstraint valueSetConstraint;
	private int? exactCallNumber;

	public ExpectedMethodCall(
		ZuraMethodInfo method,
		ValueSetConstraint valueSetConstraint,
		int? exactCallNumber)
	{
		this.method = method;
		this.valueSetConstraint = valueSetConstraint ?? new([]);
		this.exactCallNumber = exactCallNumber;
	}

	public void Verify(CallTracker tracker)
	{
		if(tracker == null)
		{
			throw new ArgumentNullException(nameof(tracker));
		}

		var actualCallCount = tracker.GetCallCount(
			this.method,
			this.valueSetConstraint);

		if(this.exactCallNumber.HasValue && actualCallCount != this.exactCallNumber.Value)
		{
			throw new ExpectationFailed(
				$"Expected call to {method.Name} exactly {this.exactCallNumber.Value} time(s), but was called {actualCallCount} time(s).");
		}
		
		if(this.exactCallNumber == null && actualCallCount == 0)
		{
			throw new ExpectationFailed(
				$"Expected a call to {method.Name}, but it was never called.");
		}
	}
}
