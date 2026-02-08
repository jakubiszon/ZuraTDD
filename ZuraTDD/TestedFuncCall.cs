using System;
using System.Threading.Tasks;

namespace ZuraTDD;

/// <summary>
/// Defines a call to a synchronous method of a test target.
/// </summary>
/// <typeparam name="Tout">Output type of the method.</typeparam>
public class TestedFuncCall<Tout>
	: ITestedMethodCall
{
	Func<object, Tout> testedMethodInvoker;

	public TestedFuncCall(
		Func<object, Tout> testedMethodInvoker)
	{
		this.testedMethodInvoker = testedMethodInvoker;
	}

	public Tout Call(object target)
	{
		return testedMethodInvoker.Invoke(target);
	}

	Task<object?> ITestedMethodCall.CallAsync(object target)
	{
		Tout result = this.Call(target);
		return Task.FromResult<object?>(result);
	}
}
