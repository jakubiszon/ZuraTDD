namespace ZuraTDD;

/// <summary>
/// Defines a dependency condition or builder which need to be built into an
/// <see cref="IDependencySetup" /> before being used inside a test.
/// This interface must be used to mark all the "When" conditions.
/// </summary>
public interface IDependencyConfiguration : ITestPart
{
	IDependencySetup Build();
}
