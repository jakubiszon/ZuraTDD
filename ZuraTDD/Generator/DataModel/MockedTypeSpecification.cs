using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class MockedTypeSpecification
{
	/// <summary>
	/// Constructor used when a type is mocked using IMock&lt;T&gt; interface.
	/// </summary>
	/// <param name="outputNamespace">Namespace into which the code will be generated.</param>
	/// <param name="type">Symbol representing the generic type declared in <see cref="IMock{TType}"/> interface.</param>
	public MockedTypeSpecification(
		string outputNamespace,
		INamedTypeSymbol type)
	{
		OutputNamespace = outputNamespace;
		TypeInfo = new TypeInfo(type);
		DeclaringNamespace = type.ContainingNamespace.ToDisplayString();
		Methods = Functions.ExtractInterfaceMethods(type);
	}

	/// <summary>
	/// Constructor used when a type is passed as a constructor parameter of a test subject.
	/// </summary>
	public MockedTypeSpecification(
		string outputNamespace,
		IParameterSymbol param)
	{
		var namedType = param.Type as INamedTypeSymbol
			?? param.Type.OriginalDefinition as INamedTypeSymbol;

		TypeInfo = namedType != null
			? new TypeInfo(namedType)
			: new TypeInfo(param);

		OutputNamespace = outputNamespace;
		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		Methods = Functions.ExtractInterfaceMethods(namedType);
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public TypeInfo TypeInfo { get; }

	public string MockedFakeTypeName => $"{TypeInfo.TypeName}_Fake";

	public string MockedTypeMethodsTypeName => $"{TypeInfo.TypeName}_Methods";

	public string BuilderTypeName => $"{TypeInfo.TypeName}_Builder";

	public string ExpectTypeName => $"{TypeInfo.TypeName}_Expect";

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used for generated output.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// List of all public methods of the mocked type.
	/// </summary>
	public IReadOnlyList<MethodSpecification> Methods { get; }
}
