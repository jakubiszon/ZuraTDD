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

	/// <summary>
	/// Returns a qualified type or namespace identifier with underscores instead of dots.
	/// </summary>
	/// <remarks>
	/// This method is used because having namespaces like "ZuraTDD.Generated.System.Collections.Generic"
	/// breaks type resolution when generated code uses "System.Collections.Generic".
	/// </remarks>
	public static string WithUnderscores(this string qualifiedIdentifier)
	{
		return qualifiedIdentifier.Replace('.', '_');
	}
}
