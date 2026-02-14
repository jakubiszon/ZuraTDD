using System;
using System.Collections.Generic;
using System.Text;

namespace ZuraTDD.Tests;

/// <summary>
/// This class illustrates throwing from async and Task returning methods.
/// </summary>
[TestClass]
public class AwaitedExceptionTests
{
	[TestMethod]
	public void ThrowBeforeTaskReturned_ThrowsImmediately()
	{
		Task? task = null;
		Assert.Throws<Exception>(() => task = ThrowBeforeTaskReturned());
		Assert.IsNull(task);
	}

	[TestMethod]
	public async Task ThrowBeforeTaskReturned_ThrowsImmediately2()
	{
		Task? task = null;
		await Assert.ThrowsAsync<Exception>(() => task = ThrowBeforeTaskReturned());
		Assert.IsNull(task);
	}

	[TestMethod]
	public async Task ThrowBeforeAwait_ThrowsWhenAwaited()
	{
		await Assert.ThrowsAsync<Exception>(ThrowBeforeAwait);
	}

	[TestMethod]
	public async Task ThrowAfterAwait_ThrowsWhenAwaited()
	{
		await Assert.ThrowsAsync<Exception>(ThrowAfterAwait);
	}

	[TestMethod]
	public async Task TaskFromException_ThrowsWhenAwaited()
	{
		await Assert.ThrowsAsync<Exception>(() => Task.FromException(new Exception()));
	}

	/// <summary>
	/// A synchronous method which throws an exception before returning a Task.
	/// </summary>
	private static Task ThrowBeforeTaskReturned()
	{
		throw new Exception();
	}

	/// <summary>
	/// An async method which throws before awaiting anything.
	/// </summary>
	private async static Task ThrowBeforeAwait()
	{
		throw new Exception();
	}

	/// <summary>
	/// An async method which throws after awaiting a Task.
	/// </summary>
	private static async Task ThrowAfterAwait()
	{
		await Task.CompletedTask;
		throw new Exception();
	}
}
