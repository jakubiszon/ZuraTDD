using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

public class CallTracker
{
	private List<CallRecord> registeredCalls = new();

	public void ReceiveCall(
		ZuraMethodInfo method,
		object?[] parameters,
		Type[]? genericArguments = null)
	{
		var receivedCall = new CallRecord(
			method,
			parameters,
			genericArguments);

		registeredCalls.Add(receivedCall);
	}

	public int GetCallCount()
	{
		return registeredCalls.Count;
	}

	public int GetCallCount(ZuraMethodInfo method)
	{
		return registeredCalls.Count(call => call.CalledMethod == method);
	}

	public int GetCallCount(
		ZuraMethodInfo method,
		ValueSetConstraint parameterFilter)
	{
		return registeredCalls
			.Count(call =>
				call.CalledMethod == method &&
				parameterFilter.Matches(call.Arguments));
	}

	public int GetCallCount(
		ZuraMethodInfo method,
		ValueSetConstraint parameterFilter,
		GenericTypeParameterSetConstraint genericParameterFilter)
	{
		return registeredCalls
			.Count(call
				=> call.CalledMethod == method
				&& parameterFilter.Matches(call.Arguments)
				&& genericParameterFilter.Matches(call.GenericArguments));
	}
}
