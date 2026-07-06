using ZuraTDD;
using static ExampleProject.Tests.GenericMethodConsumerTestCase;

namespace ExampleProject.Tests;

[TestClass]
public partial class GenericMethodConsumerTests
{
	[ZuraTest<GenericMethodConsumerTestCase>("Calling generic method without where.")]
	private ITestPart[] CallingGenericMethodWithoutWhere => [
		Receives.SomeMethod(1),

		Expect.GenericMethods
			.DoSomething<int>()
			.WasCalled(),

		Expect.GenericMethods
			.DoSomething<string>()
			.WasNotCalled(),
	];

	[ZuraTest<GenericMethodConsumerTestCase>("Calling generic method with where.")]
	private ITestPart[] CallingGenericMethodWithWhere => [
		Receives.SomeMethod(2),

		Expect.GenericMethodsWithWhere
			.DoSomething<IEnumerable<int>, int, object>()
			.WasCalled(),
	];
}
