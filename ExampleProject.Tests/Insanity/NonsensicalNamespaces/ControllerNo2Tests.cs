using ExampleProject.Insanity.NonsensicalNamespaces.Bar;
using ZuraTDD;

namespace ExampleProject.Tests.Insanity.NonsensicalNamespaces;

[TestClass]
[ZuraTestClass<ControllerInsideWeirdNamespace>]
public partial class BarControllerTests
{
	[ZuraTest("DependenciesReturnDifferentData - when same data is return - should return false")]
	public ITestPart[] DependenciesReturnDifferentData_ReturnsTrue_WhenDependenciesReturnSameData => [
		Receives.DependenciesReturnDifferentData(),

		When.ExampleRepository
			.GetData1()
			.Returns("example"),

		When.NestedNamespaceRepository
			.GetData2()
			.Returns("example"),

		Expect.ResultEqualTo(false)
	];

	[ZuraTest("DependenciesReturnDifferentData - when different data is returned - should return true")]
	public ITestPart[] DependenciesReturnDifferentData_ReturnsFakse_WhenDependenciesReturnDifferentData => [
		Receives.DependenciesReturnDifferentData(),

		When.ExampleRepository
			.GetData1()
			.Returns("example"),

		When.NestedNamespaceRepository
			.GetData2()
			.Returns("different"),

		Expect.ResultEqualTo(true)
	];
}
