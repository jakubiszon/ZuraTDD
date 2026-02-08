using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Defines a call to a no-result asynchronous method of a test target.
/// </summary>
public class TestedTaskCall
	: ITestedMethodCall
{
	Func<object, Task> testedMethodInvoker;

	public TestedTaskCall(
		Func<object, Task> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}

	public Task Call(object target)
	{
		return testedMethodInvoker.Invoke(target);
	}

	async Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		await this.Call(target);
		return null;
	}
}
