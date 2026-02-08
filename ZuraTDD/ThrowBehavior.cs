using System;

namespace ZuraTDD;

public class ThrowBehavior<TExceptionFactory> : IThrowBehavior
	where TExceptionFactory : Delegate
{
	public ThrowBehavior(TExceptionFactory exceptionFactory)
	{
		#if DEBUG
		ValidateExceptionFactoryReturnType();
		#endif
		this.ExceptionFactory = exceptionFactory;
	}

	public TExceptionFactory ExceptionFactory { get; }

	// TODO: if the constructor is guaranteed to be called from generated code, we can skip this validation and just assume the return type is correct.
	// TODO: if the constructor could be called from user-code - it would be better to use a compile time analyser to output an error.
	private static void ValidateExceptionFactoryReturnType()
	{
		var invokeMethod = typeof(TExceptionFactory).GetMethod("Invoke");
		
		if (invokeMethod == null)
		{
			throw new InvalidOperationException(
				$"Type '{typeof(TExceptionFactory).Name}' is not a valid delegate type.");
		}

		var returnType = invokeMethod.ReturnType;
		
		if (!typeof(Exception).Equals(returnType))
		{
			throw new InvalidOperationException(
				$"Delegate '{typeof(TExceptionFactory).Name}' must use 'Exception' as its declared return type.");
		}
	}
}
