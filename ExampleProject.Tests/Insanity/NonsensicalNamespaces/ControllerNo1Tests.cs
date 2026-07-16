using ExampleProject.Insanity.NonsensicalNamespaces.Foo;
using ZuraTDD;

namespace ExampleProject.Tests.Insanity.NonsensicalNamespaces;

// These tests check if correct types and namespaces are referenced in generated code
// when a class uses dependencies of same name types but different namespaces.
[TestClass]
[ZuraTestClass<ControllerInsideWeirdNamespace>]
public partial class FooControllerTests
{
	[ZuraTest("DependenciesReturnSameData - when same data is return - should return true")]
	public ITestPart[] DependenciesReturnSameData_ReturnsTrue_WhenDependenciesReturnSameData => [
		Receives.DependenciesReturnSameData(),

		When.ExampleRepository
			.GetData1()
			.Returns("example"),

		When.NestedNamespaceRepository
			.GetData2()
			.Returns("example"),

		Expect.ResultEqualTo(true)
	];

	[ZuraTest("DependenciesReturnSameData - when different data is returned - should return false")]
	public ITestPart[] DependenciesReturnSameData_ReturnsFakse_WhenDependenciesReturnDifferentData => [
		Receives.DependenciesReturnSameData(),

		When.ExampleRepository
			.GetData1()
			.Returns("example"),

		When.NestedNamespaceRepository
			.GetData2()
			.Returns("different"),

		Expect.ResultEqualTo(false)
	];
}
