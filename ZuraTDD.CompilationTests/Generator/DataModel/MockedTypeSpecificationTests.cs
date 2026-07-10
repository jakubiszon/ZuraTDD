using ZuraTDD.Generator.DataModel;

namespace ZuraTDD.CompilationTests.Generator.DataModel;

public class MockedTypeSpecificationTests
{
	[Test]
	public void MockedTypeSpecification_ShouldBeCreated()
	{
		var exampleInterface = CompilationFixture.GetNamedType("IMyStringCollection");

		Assert.That(exampleInterface, Is.Not.Null);

		var mockSpecification = new MockedTypeSpecification(
			exampleInterface.ContainingNamespace.ToDisplayString(),
			exampleInterface);

		Assert.That(mockSpecification, Is.Not.Null);
	}

	/// <summary>
	/// The type IMyStringCollection implements IList&lt;string&gt; but does not itself expose
	/// generic type parameters and all its methods are not generic.
	/// </summary>
	[Test]
	public void MockedTypeSpecification_WhenBoundGenericType_ShouldNotDefineGenericMethods()
	{
		var stringCollectionInterface = CompilationFixture.GetNamedType("IMyStringCollection");

		Assert.That(stringCollectionInterface, Is.Not.Null);

		var mockedType = new MockedTypeSpecification(
			stringCollectionInterface.ContainingNamespace.ToDisplayString(),
			stringCollectionInterface);

		Assert.That(mockedType.TypeInfo.GenericTypeParameters, Is.Empty);
		Assert.That(mockedType.Methods, Is.Not.Null);
		Assert.That(mockedType.Methods, Is.All.Matches<MethodSpecification>(m => m.GenericTypeParameters.Count == 0));
	}

	/// <summary>
	/// The type IGenericConverter has a generic type parameter and we want to see it reflected in <see cref="MockedTypeSpecification" />.
	/// </summary>
	[Test]
	public void MockedTypeSpecification_WhenUnboundGenericType_ShouldDefineGenericMethods()
	{
		var exampleInterface = CompilationFixture.GetNamedType("IGenericConverter");

		Assert.That(exampleInterface, Is.Not.Null);

		var mockedType = new MockedTypeSpecification(
			exampleInterface.ContainingNamespace.ToDisplayString(),
			exampleInterface);

		Assert.That(mockedType.TypeInfo.GenericTypeParameters, Is.Not.Empty);

		// the interface is generic but exposes no generic methods
		Assert.That(mockedType.Methods, Is.All.Matches<MethodSpecification>(m => m.GenericTypeParameters.Count == 0));
	}
}
