using System;
using System.Collections.Generic;
using System.Reflection;

namespace ZuraTDD;

/// <summary>
/// An object used to identify and distinguish methods, overloads, and generic parameters
/// used within the scope of a single mocked type.
/// </summary>
public struct ZuraMethodInfo
{
	public MethodInfo? MethodInfo { get; }

	public string? MethodKey { get; }

	public string Name => MethodInfo?.Name
		?? MethodKey!;

	public ZuraMethodInfo(MethodInfo? methodInfo)
	{
		MethodInfo = methodInfo
			?? throw new ArgumentNullException(nameof(methodInfo));

		MethodKey = null;
	}

	public ZuraMethodInfo(string? methodKey)
	{
		MethodInfo = null;

		MethodKey = methodKey
			?? throw new ArgumentNullException(nameof(methodKey));
	}

	public static implicit operator ZuraMethodInfo(MethodInfo methodInfo)
	{
		return new ZuraMethodInfo(methodInfo);
	}

	public static implicit operator ZuraMethodInfo(string methodKey)
	{
		return new ZuraMethodInfo(methodKey);
	}

	public static bool operator == (ZuraMethodInfo methodInfo, ZuraMethodInfo method)
	{
		return methodInfo.MethodInfo == method.MethodInfo
			&& methodInfo.MethodKey == method.MethodKey;
	}

	public static bool operator != (ZuraMethodInfo methodInfo, ZuraMethodInfo method)
	{
		return methodInfo.MethodInfo != method.MethodInfo
			|| methodInfo.MethodKey != method.MethodKey;
	}

	public override bool Equals(object? obj)
	{
		return obj is ZuraMethodInfo info
			&& EqualityComparer<MethodInfo?>.Default.Equals(MethodInfo, info.MethodInfo)
			&& MethodKey == info.MethodKey;
	}

	public override int GetHashCode() => (MethodInfo, MethodKey).GetHashCode();
}
