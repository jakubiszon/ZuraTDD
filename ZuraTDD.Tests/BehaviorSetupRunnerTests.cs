using System;
using System.Collections.Generic;
using System.Text;

namespace ZuraTDD.Tests;

[TestClass]
public class BehaviorSetupRunnerTests
{
	[TestMethod]
	public void InvokeActionBehavior_EmptyRunner_DoesNotThrow()
	{
		var runner = new BehaviorSetupRunner();
		var methodInfo = typeof(BehaviorSetupRunnerTests).GetMethod(nameof(InvokeActionBehavior_EmptyRunner_DoesNotThrow));

		runner.InvokeActionBehavior(methodInfo!);
		runner.InvokeActionBehavior(methodInfo!, 1);
		runner.InvokeActionBehavior(methodInfo!, 1, 2);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
	}

	[TestMethod]
	public void InvokeFuncBehavior_EmptyRunner_DoesNotThrow()
	{
		var runner = new BehaviorSetupRunner();
		var methodInfo = typeof(string).GetMethod(nameof(string.Trim), []);

		// note - the string.Empty works as the default result parameter
		runner.InvokeFuncBehavior(methodInfo!, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, string.Empty);
	}

	/// <summary>
	/// Verifies that the correct behavior-setup is executed based on the provided value constraints.
	/// </summary>
	[TestMethod]
	public void InvokeActionBehavior_UsesFilters()
	{
		var sideEffectCount_1 = 0;
		var sideEffectCount_2 = 0;

		var methodInfo = typeof(string).GetMethod(nameof(string.Trim), [])!;

		var behaviorSetups = new List<BehaviorSetup>
		{
			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 100)]),
				[new SideEffectBehavior<Action<int>>(x => sideEffectCount_1++)]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x <= 100)]),
				[new SideEffectBehavior<Action<int>>(x => sideEffectCount_2++)])
		};

		var runner = new BehaviorSetupRunner(behaviorSetups);

		runner.InvokeFuncBehavior(methodInfo, 1, string.Empty);
		Assert.AreEqual(0, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);

		runner.InvokeFuncBehavior(methodInfo, 101, string.Empty);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);
	}
}
