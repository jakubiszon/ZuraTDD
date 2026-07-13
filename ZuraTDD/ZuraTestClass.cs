using System;

namespace ZuraTDD;

/// <summary>
/// Marks a test class as targeting the specified subject type.
/// The decorated class must be <c>public partial</c>.
/// Generates Receives, When, and Expect builders as well as dependency scaffolding
/// and an implicit TestCase for the subject type.
/// </summary>
/// <typeparam name="TSubject">The type being tested.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ZuraTestClass<TSubject> : Attribute
{
}
