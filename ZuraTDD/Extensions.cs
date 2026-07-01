using System;
using System.Collections.Generic;

namespace ZuraTDD;

internal static class Extensions
{
	public static IEnumerable<Titem> DistinctBy<Titem, Tcheck>(
		this IEnumerable<Titem> sournce,
		Func<Titem, Tcheck> keyFactory)
	{
		HashSet<Tcheck> seen = new();
		foreach (var item in sournce)
		{
			if (seen.Add(keyFactory(item)))
			{
				yield return item;
			}
		}
	}
}
