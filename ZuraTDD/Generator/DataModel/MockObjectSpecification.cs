using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Represents information about a class declared as implementing the <see cref="IMock{T}"/> interface.
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
	/// Returns the specification of the service being mocked.
	/// </summary>
	public ServiceSpecification MockedTypeSpecification { get; }

	public MockObjectSpecification(
		INamedTypeSymbol typeSymbol)
	{
		OutputNamespace = typeSymbol.ContainingNamespace.ToDisplayString();
		TypeName = typeSymbol.Name;

		var mockedType = typeSymbol.Interfaces.FirstOrDefault(Functions.ImplementsMockInterface)
			?.TypeArguments[0] as INamedTypeSymbol
			?? throw new InvalidOperationException("Test case type does not implement IMock<T>");

		MockedTypeSpecification = new ServiceSpecification(
			OutputNamespace,
			mockedType);
	}
}
