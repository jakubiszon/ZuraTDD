using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ZuraTDD.BuildingBlocks;

internal static class TypeMatcherHelper
{
	private static readonly Type typeMatcherInterface = typeof(ITypeMatcher);
	private static readonly ConcurrentDictionary<Type, bool> typeMatcherDependencyDictionary = new(InitialMatcherDependencies());

	public static bool DependsOnTypeMatcher<T>()
	{
		return typeMatcherDependencyDictionary.GetOrAdd(typeof(T), DependsOnTypeMatcherInternal);
	}

	private static bool DependsOnTypeMatcherInternal(Type type)
	{
		// Direct match - type is or implements ITypeMatcher
		if (typeMatcherInterface.IsAssignableFrom(type))
		{
			return true;
		}

		// Array types (e.g., ITypeMatcher[])
		if (type.IsArray)
		{
			return DependsOnTypeMatcherInternal(type.GetElementType()!);
		}

		// Generic type arguments (e.g., List<ITypeMatcher>, Func<int, ITypeMatcher>)
		if (type.IsGenericType)
		{
			foreach(var typeArgument in type.GenericTypeArguments)
			{
				if (DependsOnTypeMatcherInternal(typeArgument))
				{
					return true;
				}
			}
		}

		// By-reference types (e.g., ref ITypeMatcher)
		if (type.IsByRef)
		{
			return DependsOnTypeMatcherInternal(type.GetElementType()!);
		}

		// Pointer types (e.g., ITypeMatcher*)
		if (type.IsPointer)
		{
			return DependsOnTypeMatcherInternal(type.GetElementType()!);
		}

		return false;
	}

	private static IEnumerable<KeyValuePair<Type, bool>> InitialMatcherDependencies()
	{
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyType), true);
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyType[]), true);
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyValueType), true);
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyValueType[]), true);
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyReferenceType), true);
		yield return new KeyValuePair<Type, bool>(typeof(GenericArgument.AnyReferenceType[]), true);
	}
}
