using ZuraTDD.Exceptions;
using System;

namespace ZuraTDD;

public class ExpectedResultMatching<T> : ITestResultExpectation
{
	private readonly Predicate<T> predicate;

	public ExpectedResultMatching(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public void Verify(ITestResult testSubjectServices)
	{
		if (testSubjectServices.Result is T result)
		{
			if(!this.predicate(result))
			{
				// TODO: if an Exression<...> was used - would it be possible to give more info here?
				throw new ExpectationFailed("Returned value did not match the predicate.");
			}
		}
		else
		{
			var type = testSubjectServices.Result?.GetType() ?? typeof(object);
			throw new ExpectationFailed($"Returned value type is '{type.FullName}' but was expected to be '{typeof(T).FullName}'.");
		}
	}
}
