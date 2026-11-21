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

	/// <summary>
	/// Check that a generic type param used as method input param is seen as generic.
	/// </summary>
	[TestMethod]
	public void MockedTypeSpecification_WhenUnboundGenericType_ShouldDefineGenericParameters()
	{
		var exampleInterface = CompilationFixture.GetNamedType("IGenericConverter");

		Assert.IsNotNull(exampleInterface);

		var mockedType = new MockedTypeSpecification(exampleInterface);

		Assert.IsNotEmpty(mockedType.TypeInfo.GenericTypeParameters);

		// exoect "ExampleMethod" which has a paraneter of type "T" passed from the definition of IGenericConverter
		var inputTypes = mockedType.Methods
			.Where(m => m.MethodName == "ExampleMethod")
			.SelectMany(m => m.Parameters.Select(p => p.Type))
			.ToArray();

		CollectionAssert.Contains(inputTypes, "T");
	}

	/// <summary>
	/// This tests ensures that analysis of a type produces correct models of its dependencies.
	/// The dependencies should store applied type arguments in <see cref="DependencySpecification" /> class.
	/// Inside each definition there should be a <see cref="MockedTypeSpecification" /> which should define its generic type params
	/// as in its own declaration and should be "polluted" with applied type arguments carried over from the consumer.
	/// </summary>
	[TestMethod]
	public void MockedTypeSpecification_DefinedFromConstructorParam_ShoudDefineGenericParameter()
	{
		var consumerClass = CompilationFixture.GetNamedType("GenericConverterConsumer");

		Assert.IsNotNull(consumerClass);

		var testCaseSubject = new TestCaseSubject(consumerClass);

		Assert.ContainsSingle(testCaseSubject.DependenciesClass.Dependencies);

		// make sure we know what type arguments are applied from the point of view of the consumer class
		var dependency = testCaseSubject.DependenciesClass.Dependencies[0];
		Assert.AreEqual("long", dependency.AppliedTypeParamNames.First());

		// make sure we treat the consumed class as generic and we do not pollute it with applied type argument data
		var mockedType = dependency.MockedType;
		Assert.IsNotNull(mockedType);
		Assert.IsNotEmpty(mockedType.TypeInfo.GenericTypeParameters);

		// exoect "ExampleMethod" which has a paraneter of type "T" passed from the definition of IGenericConverter
		var inputTypes = mockedType.Methods
			.Where(m => m.MethodName == "ExampleMethod")
			.SelectMany(m => m.Parameters.Select(p => p.Type))
			.ToArray();

		CollectionAssert.Contains(inputTypes, "T");
	}
}
