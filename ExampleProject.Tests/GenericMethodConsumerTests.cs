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

		// make sure DoSomething<T1,T2,T3> was not calledregardless of the generic type arguments
		Expect.GenericMethodsWithWhere
			.DoSomething<GenericArgument.AnyType, GenericArgument.AnyType, GenericArgument.AnyType>()
			.WasNotCalled(),
	];

	[ZuraTest<GenericMethodConsumerTestCase>("Calling generic method with where.")]
	private ITestPart[] CallingGenericMethodWithWhere => [
		Receives.SomeMethod(2),

		// make sure DoSomething was called with the expected generic type arguments
		Expect.GenericMethodsWithWhere
			.DoSomething<IEnumerable<int>, int, object>()
			.WasCalled(),

		// make sure DoSomething was called just once regardless of the generic type arguments
		// in other words - no calls other than the one we expected
		Expect.GenericMethodsWithWhere
			.DoSomething<GenericArgument.AnyType, GenericArgument.AnyType, GenericArgument.AnyType>()
			.WasCalled(1),
	];
}
