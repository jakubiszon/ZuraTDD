using System;

namespace ZuraTDD;

/// <summary>
/// Marks a test class as targeting the specified subject type.
/// The decorated class must be <c>public partial</c> as it will be extended with genrated code
/// defining <c>Receives</c>, <c>When</c>, and <c>Expect</c> builders for the test subject type.
/// </summary>
/// <typeparam name="TSubject">The type which you want to test in the decorated class.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ZuraTestClass<TSubject> : Attribute
{
}
