namespace ZuraTDD.BuildingBlocks;

/// <summary>
/// A delegate type allowing verify calls accepting dependency-call-expectations prepared with <c>Expect</c> builders.
/// </summary>
public delegate void VerifyCallback(params ExpectedMockedObjectMethodCall[] expectations);
