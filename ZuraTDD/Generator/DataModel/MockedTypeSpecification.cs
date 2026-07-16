using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

internal class MockedTypeSpecification
{
	/// <summary>
	/// Constructor used when a type is mocked using IMock&lt;T&gt; interface.
	/// </summary>
	/// <param name="type">Symbol representing the generic type declared in <see cref="IMock{TType}"/> interface.</param>
	public MockedTypeSpecification(
		INamedTypeSymbol type)
	{
		TypeInfo = new TypeInfo(type);
		DeclaringNamespace = type.ContainingNamespace.ToDisplayString();
		Methods = Functions.ExtractInterfaceMethods(type);
	}

	/// <summary>
	/// Constructor used when a type is passed as a constructor parameter of a test subject.
	/// </summary>
	public MockedTypeSpecification(
		IParameterSymbol param)
	{
		var namedType = param.Type as INamedTypeSymbol
			?? param.Type.OriginalDefinition as INamedTypeSymbol;

		TypeInfo = namedType != null
			? new TypeInfo(namedType)
			: new TypeInfo(param);

		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		Methods = Functions.ExtractInterfaceMethods(namedType);
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public TypeInfo TypeInfo { get; }

	/// <summary>
	/// Name of the type used internally to impersonate instances of the mocked type.
	/// </summary>
	public string MockedFakeTypeName => $"{TypeInfo.TypeName}_Fake";

	/// <summary>
	/// Name of a static type defining the methods of the mocked type.
	/// This type will be used by the builder (when specifying behaviors),
	/// the fake (to track the actual calls), and the expect (to verify the calls).
	/// </summary>
	public string MockedTypeMethodsTypeName => $"{TypeInfo.TypeName}_Methods";

	public string BuilderTypeName => $"{TypeInfo.TypeName}_Builder";

	public string ExpectTypeName => $"{TypeInfo.TypeName}_Expect";

	/// <summary>
	/// Gets the prefix for file names which will contain generated code
	/// e.g. "_Methods" class.
	/// </summary>
	public string OutputFilePrefix => $"{OutputNamespace}.{TypeInfo.TypeName}";

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used for generated output.
	/// </summary>
	public string OutputNamespace => $"ZuraTDD.Generated_{DeclaringNamespace.WithUnderscores()}";

	/// <summary>
	/// List of all public methods of the mocked type.
	/// </summary>
	public IReadOnlyList<MethodSpecification> Methods { get; }
}
