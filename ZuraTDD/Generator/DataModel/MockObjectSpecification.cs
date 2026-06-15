using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Represents information about a class declared as implementing the <see cref="IMock{T}"/> interface.
/// This class will be used to mock the type specified as the generic parameter.
/// </summary>
internal class MockObjectSpecification
{
	/// <summary>
	/// Returns the namespace in which the class was declared by the user.
	/// It will also be the namespace of the generated code.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Returns the name of the class as it was declared by the user.
	/// </summary>
	public string TypeName { get; }

	/// <summary>
	/// Returns the specification of the mocked type - one declared as the generic parameter of the <see cref="IMock{T}"/> interface.
	/// </summary>
	public MockedTypeSpecification MockedTypeSpecification { get; }

	/// <summary>
	/// Prepares an instance of the <see cref="MockObjectSpecification"/> class based on the provided symbol.
	/// </summary>
	/// <param name="typeSymbol">The type which implements the <see cref="IMock{T}"/> interface.</param>
	/// <exception cref="InvalidOperationException"></exception>
	public MockObjectSpecification(
		INamedTypeSymbol typeSymbol)
	{
		OutputNamespace = typeSymbol.ContainingNamespace.ToDisplayString();
		TypeName = typeSymbol.Name;

		var mockedType = typeSymbol.Interfaces.FirstOrDefault(Functions.ImplementsMockInterface)
			?.TypeArguments[0] as INamedTypeSymbol
			?? throw new InvalidOperationException("Test case type does not implement IMock<T>");

		MockedTypeSpecification = new MockedTypeSpecification(
			OutputNamespace,
			mockedType);
	}
}
