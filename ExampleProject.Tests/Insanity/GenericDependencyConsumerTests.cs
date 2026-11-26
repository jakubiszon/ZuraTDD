using ExampleProject.Insanity;
using ZuraTDD;

namespace ExampleProject.Tests.Insanity;

[TestClass]
[ZuraTestClass<GenericDependencyConsumer>]
public partial class GenericDependencyConsumerTests
{
	[ZuraTest("Verify setting up generic input and output.")]
	private ITestPart[] xxx => [
		Receives.AddItemsAndReturnSumFromDependency([1,2,3]),

		When.GenericDependency.GetItems()
			.Returns(new int[] { 4,5,6 }.AsEnumerable()),

		Expect.GenericDependency.GetItems()
			.WasCalled(),

		Expect.GenericDependency.AddItem()
			.WasCalled(3),

		Expect.GenericDependency.AddItem(1)
			.WasCalled(1),

		Expect.GenericDependency.AddItem(new(x => x > 1))
			.WasCalled(2),

		Expect.ResultEqualTo(15) // 15 is the sum of the input
	];
}
