using ZuraTDD.Generator.DataModel;

namespace ZuraTDD.CompilationTests.Generator.DataModel;

[TestClass]
public class MockedTypeSpecificationTests
{
	[TestMethod]
	public void MockedTypeSpecification_ShouldBeCreated()
	{
		var exampleInterface = CompilationFixture.GetNamedType("IMyStringCollection");

		Assert.IsNotNull(exampleInterface);

		var mockSpecification = new MockedTypeSpecification(exampleInterface);

		Assert.IsNotNull(mockSpecification);
	}

	/// <summary>
	/// The type IMyStringCollection implements IList&lt;string&gt; but does not itself expose
	/// generic type parameters and all its methods are not generic.
	/// </summary>
	[TestMethod]
	public void MockedTypeSpecification_WhenBoundGenericType_ShouldNotDefineGenericMethods()
	{
		var stringCollectionInterface = CompilationFixture.GetNamedType("IMyStringCollection");

		Assert.IsNotNull(stringCollectionInterface);

		var mockedType = new MockedTypeSpecification(stringCollectionInterface);

		Assert.IsEmpty(mockedType.TypeInfo.GenericTypeParameters);
		Assert.IsNotNull(mockedType.Methods);
		Assert.IsTrue(mockedType.Methods.All(m => m.GenericTypeParameters.Count == 0));
	}

	/// <summary>
	/// The type IGenericConverter has a generic type parameter and we want to see it reflected in <see cref="MockedTypeSpecification" />.
	/// </summary>
	[TestMethod]
	public void MockedTypeSpecification_WhenUnboundGenericType_ShouldDefineGenericMethods()
	{
		var exampleInterface = CompilationFixture.GetNamedType("IGenericConverter");

		Assert.IsNotNull(exampleInterface);

		var mockedType = new MockedTypeSpecification(exampleInterface);

		Assert.IsNotEmpty(mockedType.TypeInfo.GenericTypeParameters);

		// the interface is generic but exposes no generic methods
		Assert.IsTrue(mockedType.Methods.All(m => m.GenericTypeParameters.Count == 0));
	}
}
