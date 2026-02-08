using System;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Defines a call to a void method of a test target.
/// </summary>
public class TestedActionCall
	: ITestedMethodCall
{
	Action<object> testedMethodInvoker;
	public TestedActionCall(
		Action<object> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}
	public void Call(object target)
	{
		testedMethodInvoker.Invoke(target);
	}

	Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		this.Call(target);
		return Task.FromResult<object?>(null);
	}
}
