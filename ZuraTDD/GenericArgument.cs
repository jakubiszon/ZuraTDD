using System;
using ZuraTDD.BuildingBlocks;

namespace ZuraTDD;

/// <summary>
/// This class defines special types which can be used as generic type arguments
/// to match or exclude calls to generic methods.
/// </summary>
/// <example>
/// Expect.Logger.Log&lt;GenericArgument.Any&gt;().WasCalled();
/// </example>
public class GenericArgument
{
	public class AnyType : ITypeMatcher
	{
		public bool IsMatching(Type type)
		{
			return true;
		}
	}

	public class AnyValueType : ITypeMatcher
	{
		public bool IsMatching(Type type)
		{
			return type.IsValueType;
		}
	}

	public class AnyReferenceType : ITypeMatcher
	{
		public bool IsMatching(Type type)
		{
			return !type.IsValueType;
		}
	}

	//public class Inheriting<T> : ITypeMatcher
	//{
	//	public bool IsMatching(Type type)
	//	{
	//		return type == typeof(T) || type.IsSubclassOf(typeof(T));
	//	}
	//}

	//public class NotInheriting<T> : ITypeMatcher
	//{
	//	public bool IsMatching(Type type)
	//	{
	//		return type != typeof(T) && !type.IsSubclassOf(typeof(T));
	//	}
	//}

	//public class AnyOf<T1, T2> : ITypeMatcher
	//{
	//	public bool IsMatching(Type type)
	//	{
	//		return type == typeof(T1) || type == typeof(T2);
	//	}
	//}

	//public class AnyOf<T1, T2, T3> : ITypeMatcher
	//{
	//	public bool IsMatching(Type type)
	//	{
	//		return type == typeof(T1) || type == typeof(T2) || type == typeof(T3);
	//	}
	//}
}
