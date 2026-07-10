using System;

namespace ZuraTDD.BuildingBlocks;

/// <summary>
/// Flags types which define custom type matching logic to use
/// when the type is passed to <see cref="GenericTypeParameterConstraint" />.
/// </summary>
/// <remarks>
/// All implementing types must have a public parameterless constructor and be immutable and thread-safe.
/// </remarks>
internal interface ITypeMatcher
{
	bool IsMatching(Type type);
}
