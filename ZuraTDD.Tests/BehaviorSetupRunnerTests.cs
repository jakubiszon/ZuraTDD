using ZuraTDD.BuildingBlocks;

namespace ZuraTDD.Tests;

/// <summary>
/// This class contains some basic and more complex tests for the <see cref="BehaviorSetupRunner"/> class.
/// When writing tests working with actual filters - pay close attention to setup and pass the right number and type of parameters.
/// </summary>
[TestClass]
public class BehaviorSetupRunnerTests
{
	[TestMethod]
	public void InvokeActionBehavior_EmptyRunner_DoesNotThrow()
	{
		var runner = new BehaviorSetupRunner();
		var methodInfo = typeof(BehaviorSetupRunnerTests).GetMethod(nameof(InvokeActionBehavior_EmptyRunner_DoesNotThrow));

		runner.InvokeActionBehavior(methodInfo!, []);
		runner.InvokeActionBehavior(methodInfo!, 1, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, []);
		runner.InvokeActionBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, []);
	}

	[TestMethod]
	public void InvokeFuncBehavior_EmptyRunner_DoesNotThrow()
	{
		var runner = new BehaviorSetupRunner();
		var methodInfo = typeof(string).GetMethod(nameof(string.Trim), []);

		// note - the string.Empty works as the default result parameter
		runner.InvokeFuncBehavior(methodInfo!, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, [], string.Empty);
		runner.InvokeFuncBehavior(methodInfo!, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, [], string.Empty);
	}

	/// <summary>
	/// Verifies that the correct behavior-setup is executed based on the provided value constraints.
	/// </summary>
	[TestMethod]
	public void InvokeFuncBehavior_UsesFilters()
	{
		var sideEffectCount_1 = 0;
		var sideEffectCount_2 = 0;

		var methodInfo = typeof(string).GetMethod(nameof(string.Trim), [])!;

		var behaviorSetups = new List<BehaviorSetup>
		{
			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 100)]),
				new ([]),
				[new SideEffectBehavior<Action<int>>(x => sideEffectCount_1++)]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x <= 100)]),
				new ([]),
				[new SideEffectBehavior<Action<int>>(x => sideEffectCount_2++)])
		};

		var runner = new BehaviorSetupRunner(behaviorSetups);

		runner.InvokeFuncBehavior(methodInfo, 1, [], string.Empty);
		Assert.AreEqual(0, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);

		runner.InvokeFuncBehavior(methodInfo, 101, [], string.Empty);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);
	}

	/// <summary>
	/// Verifies that the correct behavior-setup is executed based on the provided generic type parameter constraints.
	/// </summary>
	[TestMethod]
	public void InvokeFuncBehavior_UsesGenericFilters()
	{
		var sideEffectCount_1 = 0;
		var sideEffectCount_2 = 0;

		var methodInfo = new ZuraMethodInfo("ExampleMethod");

		var behaviorSetups = new List<BehaviorSetup>
		{
			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([]),
				new ([new GenericTypeParameterConstraint(typeof(string))]),
				[new SideEffectBehavior<Action>(() => sideEffectCount_1++)]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([]),
				new ([new GenericTypeParameterConstraint(typeof(decimal))]),
				[new SideEffectBehavior<Action>(() => sideEffectCount_2++)])
		};

		var runner = new BehaviorSetupRunner(behaviorSetups);

		runner.InvokeFuncBehavior(methodInfo, [typeof(string)], string.Empty);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(0, sideEffectCount_2);

		runner.InvokeFuncBehavior(methodInfo, [typeof(decimal)], string.Empty);
		Assert.AreEqual(1, sideEffectCount_1);
		Assert.AreEqual(1, sideEffectCount_2);
	}

	/// <summary>
	/// Verifies that the correct behavior-setup is executed based on the provided value constraints.
	/// </summary>
	[TestMethod]
	public void InvokeFuncBehavior_UsesGenericAndValueFilters()
	{
		var sideEffectValue = "";

		var methodInfo = new ZuraMethodInfo("ExampleMethod");

		var behaviorSetups = new List<BehaviorSetup>
		{
			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x < 10), new ValueConstraint<int>()]),
				new ([new GenericTypeParameterConstraint(typeof(string))]),
				[new SideEffectBehavior<Action<int, int>>((x, y) => sideEffectValue = "x < 10 and string type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x < 10), new ValueConstraint<int>()]),
				new ([new GenericTypeParameterConstraint(typeof(int))]),
				[new SideEffectBehavior<Action<int, int>>((x, y) => sideEffectValue = "x < 10 and int type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 10), new ValueConstraint<int>()]),
				new ([new GenericTypeParameterConstraint(typeof(string))]),
				[new SideEffectBehavior<Action<int, int>>((x, y) => sideEffectValue = "x > 10 and string type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 10), new ValueConstraint<int>()]),
				new ([new GenericTypeParameterConstraint(typeof(int))]),
				[new SideEffectBehavior<Action<int, int>>((x, y) => sideEffectValue = "x > 10 and int type")]),
		};

		var runner = new BehaviorSetupRunner(behaviorSetups);

		runner.InvokeFuncBehavior(methodInfo, 1, 100, [typeof(int)], string.Empty);
		Assert.AreEqual("x < 10 and int type", sideEffectValue);

		runner.InvokeFuncBehavior(methodInfo, 100, 100, [typeof(string)], string.Empty);
		Assert.AreEqual("x > 10 and string type", sideEffectValue);

		runner.InvokeFuncBehavior(methodInfo, 1, 100, [typeof(int)], string.Empty);
		Assert.AreEqual("x < 10 and int type", sideEffectValue);

		runner.InvokeFuncBehavior(methodInfo, 100, 100, [typeof(string)], string.Empty);
		Assert.AreEqual("x > 10 and string type", sideEffectValue);
	}

	[TestMethod]
	public void InvokeFuncBehavior_WithReturnBehaviors_ReturnsMatchedValue()
	{
		var methodInfo = new ZuraMethodInfo("ExampleMethod");

		var behaviorSetups = new List<BehaviorSetup>
		{
			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x < 10)]),
				new ([new GenericTypeParameterConstraint(typeof(string))]),
				[new ReturnBehavior<Func<int, string>>(x => "x < 10 and string type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x < 10)]),
				new ([new GenericTypeParameterConstraint(typeof(int))]),
				[new ReturnBehavior<Func<int, string>>(x => "x < 10 and int type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 10)]),
				new ([new GenericTypeParameterConstraint(typeof(string))]),
				[new ReturnBehavior<Func<int, string>>(x => "x > 10 and string type")]),

			new BehaviorSetup(
				methodInfo,
				new ValueSetConstraint([new ValueConstraint<int>(x => x > 10)]),
				new ([new GenericTypeParameterConstraint(typeof(int))]),
				[new ReturnBehavior<Func<int, string>>(x => "x > 10 and int type")]),
		};

		var runner = new BehaviorSetupRunner(behaviorSetups);

		var result1 = runner.InvokeFuncBehavior(methodInfo, 1, [typeof(string)], string.Empty);
		Assert.AreEqual("x < 10 and string type", result1);

		var result2 = runner.InvokeFuncBehavior(methodInfo, 11, [typeof(string)], string.Empty);
		Assert.AreEqual("x > 10 and string type", result2);

		var result3 = runner.InvokeFuncBehavior(methodInfo, 1, [typeof(int)], string.Empty);
		Assert.AreEqual("x < 10 and int type", result3);

		var result4 = runner.InvokeFuncBehavior(methodInfo, 11, [typeof(int)], string.Empty);
		Assert.AreEqual("x > 10 and int type", result4);

		var result5 = runner.InvokeFuncBehavior(methodInfo, 11, [typeof(IComparable)], "default used because generic params are not matched");
		Assert.AreEqual("default used because generic params are not matched", result5);
	}
}
