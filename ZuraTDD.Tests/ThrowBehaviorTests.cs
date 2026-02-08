namespace ZuraTDD.Tests;

#if DEBUG

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

	[TestMethod]
	public void Constructor_InvalidExceptionFactory_Throws()
	{
		// Arrange
		Func<TestException> exceptionFactory = () => new TestException();

		// Act & Assert
		Assert.Throws<InvalidOperationException>(
			() => new ThrowBehavior<Func<TestException>>(exceptionFactory));
	}

	[TestMethod]
	public void Constructor_NonReturningExceptionFactory_Throws()
	{
		// Arrange
		Action action = () => { };

		// Act & Assert
		Assert.Throws<InvalidOperationException>(
			() => new ThrowBehavior<Action>(action));
	}
}

#endif
