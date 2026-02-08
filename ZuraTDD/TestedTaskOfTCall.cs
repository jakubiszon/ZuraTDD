using System;
using System.Threading.Tasks;

namespace ZuraTDD;

public class TestedTaskOfTCall<Tout>
	: ITestedMethodCall
{
	Func<object, Task<Tout>> testedMethodInvoker;

	public TestedTaskOfTCall(
		Func<object, Task<Tout>> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}

	public Task<Tout> Call(object target)
	{
		return testedMethodInvoker.Invoke(target);
	}

	async Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		return await this.Call(target);
	}
}
