using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a dependency accepted as one constructor parameters by the test subject class.
/// </summary>
internal class DependencySpecification
{
	/// <summary>
	/// Constructor used when a type is mocked using IMock&lt;T&gt; interface.
	/// </summary>
	/// <param name="typeSymbol">Symbol which was declares as implementing the <see cref="IMock{TType}"/> interface.</param>
	public DependencySpecification(
		string outputNamespace,
		INamedTypeSymbol mockedType)
	{
		string mockedTypeName = mockedType.ToDisplayString();

		OutputNamespace = outputNamespace;
		MockedTypeName = mockedType.Name;
		DeclaringNamespace = mockedType.ContainingNamespace.ToDisplayString();
		FullyQualifiedName = mockedType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));
		IsInterface = mockedType.TypeKind == TypeKind.Interface;

		// TODO: use inheritance to apply this field only to services used by TestCase<T>
		DependencyPropertyName = string.Empty;
		
		Methods = Functions.ExtractPublicMethods(mockedType);
	}

	/// <summary>
	/// Constructor used when a type is passed as a constructor parameter of a test subject.
	/// </summary>
	public DependencySpecification(
		string outputNamespace,
		IParameterSymbol param)
	{
		OutputNamespace = outputNamespace;
		MockedTypeName = param.Type.Name;
		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		DependencyPropertyName = param.Name.ToString().Capitalize();
		FullyQualifiedName = param.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));
		IsInterface = param.Type.TypeKind == TypeKind.Interface;
		
		Methods = Functions.ExtractPublicMethods(param.Type as INamedTypeSymbol);
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public string MockedTypeName { get; }

	/// <summary>
	/// Gets the fully qualified name of the object, including its namespace or containing context.
	/// </summary>
	public string FullyQualifiedName { get; }

	public string MockedFakeTypeName => $"{MockedTypeName}_Fake";

	public string MockedTypeMethodsTypeName => $"{MockedTypeName}_Methods";

	public string BuilderTypeName => $"{MockedTypeName}_Builder";

	public string ExpectTypeName => $"{MockedTypeName}_Expect";

	public string MockTypeName => $"{MockedTypeName}_Mock";

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used for generated output.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Name of the property in the TestSubjecyDependencies class generated for the test cases which reference the test subject.
	/// </summary>
	public string DependencyPropertyName { get; }

	/// <summary>
	/// List of all public methods of the mocked type.
	/// </summary>
	public IReadOnlyList<MethodSpecification> Methods { get; }

	/// <summary>
	/// Returns true if the dependency is an interface and can be mocked.
	/// </summary>
	public bool IsInterface { get; }
}
