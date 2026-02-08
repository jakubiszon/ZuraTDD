using System;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Defines a call to an asynchronous method of a test target
/// that returns a value of type <see cref="Tout" /> wrapped in a <see cref="ValueTask" />.
/// </summary>
public class TestedValueTaskOfTCall<Tout>
	: ITestedMethodCall
{
	Func<object, ValueTask<Tout>> testedMethodInvoker;

	public TestedValueTaskOfTCall(
		Func<object, ValueTask<Tout>> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}

	public ValueTask<Tout> Call(object target)
	{
		return testedMethodInvoker.Invoke(target);
	}

	async Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		return await this.Call(target);
	}
}
