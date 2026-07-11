namespace ZuraTDD.Tests;

[TestClass]
public class ThrowBehaviorTests
{
	[TestMethod]
	public void Constructor_ValidExceptionFactory_DoesNotThrow()
	{
		// Arrange
		Func<Exception> exceptionFactory = () => new InvalidOperationException("Test exception");

		// Act & Assert
		var behavior = new ThrowBehavior<Func<Exception>>(exceptionFactory);
	}

#if DEBUG
	/// <summary>
	/// Ensures that a factory method passed to <see cref="ThrowBehavior" /> declares exactly
	/// <see cref="Exception" /> as its return type.
	/// This test is only run in debug mode.
	/// </summary>
	[TestMethod]
	public void Constructor_InvalidExceptionFactory_Throws()
	{
		// Arrange
		Func<TestException> exceptionFactory = () => new TestException();

		// Act & Assert
		Assert.Throws<InvalidOperationException>(
			() => new ThrowBehavior<Func<TestException>>(exceptionFactory));
	}

	/// <summary>
	/// Ensures that a void method passed to <see cref="ThrowBehavior" /> is not accepted.
	/// This test is only run in debug mode.
	/// </summary>
	[TestMethod]
	public void Constructor_NonReturningExceptionFactory_Throws()
	{
		// Arrange
		Action action = () => { };

		// Act & Assert
		Assert.Throws<InvalidOperationException>(
			() => new ThrowBehavior<Action>(action));
	}
#endif
}
