using System;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Defines a call to a no-result asynchronous method of a test target.
/// </summary>
internal class TestedValueTaskCall
	: ITestedMethodCall
{
	Func<object, ValueTask> testedMethodInvoker;

	public TestedValueTaskCall(
		Func<object, ValueTask> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}

	public ValueTask Call(object target)
	{
		return testedMethodInvoker.Invoke(target);
	}

	async Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		await this.Call(target);
		return null;
	}
}
