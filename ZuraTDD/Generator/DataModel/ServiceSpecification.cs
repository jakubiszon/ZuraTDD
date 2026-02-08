using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a service accepted as one constructor parameters by the test subject class.
/// </summary>
internal class ServiceSpecification // TODO: rename it
{
	/// <summary>
	/// Constructor used when a service is mocked using IMock&lt;T&gt; interface.
	/// </summary>
	/// <param name="typeSymbol">Symbol which was declares as implementing the <see cref="IMock{TService}"/> interface.</param>
	public ServiceSpecification(
		string outputNamespace,
		INamedTypeSymbol mockedType)
	{
		string mockedTypeName = mockedType.ToDisplayString();

		OutputNamespace = outputNamespace;
		ServiceTypeName = mockedType.Name;
		DeclaringNamespace = mockedType.ContainingNamespace.ToDisplayString();
		FullyQualifiedName = mockedType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));

		// TODO: use inheritance to apply this field only to services used by TestCase<T>
		ServicePropertyName = string.Empty;
		
		Methods = Functions.ExtractPublicMethods(mockedType);
	}

	/// <summary>
	/// Constructor used when a service is defined as a parameter of the test subject's constructor.
	/// </summary>
	public ServiceSpecification(
		string outputNamespace,
		IParameterSymbol param)
	{
		OutputNamespace = outputNamespace;
		ServiceTypeName = param.Type.Name;
		DeclaringNamespace = param.Type.ContainingNamespace.ToDisplayString();
		ServicePropertyName = param.Name.ToString().Capitalize();
		FullyQualifiedName = param.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining));
		
		Methods = Functions.ExtractPublicMethods(param.Type as INamedTypeSymbol);
	}

	/// <summary>
	/// Name of the mocked type without the namespace.
	/// </summary>
	public string ServiceTypeName { get; }

	/// <summary>
	/// Gets the fully qualified name of the object, including its namespace or containing context.
	/// </summary>
	public string FullyQualifiedName { get; }

	public string ServiceFakeTypeName => $"{ServiceTypeName}_Fake";

	public string ServiceMethodsTypeName => $"{ServiceTypeName}_Methods";

	public string BuilderTypeName => $"{ServiceTypeName}_Builder";

	public string ExpectTypeName => $"{ServiceTypeName}_Expect";

	public string MockTypeName => $"{ServiceTypeName}_Mock";

	/// <summary>
	/// Namespace containing the mocked type.
	/// </summary>
	public string DeclaringNamespace { get; }

	/// <summary>
	/// Gets the namespace that will be used for generated output.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Name of the property in the services class generated for the test cases which reference the test subject.
	/// </summary>
	public string ServicePropertyName { get; }

	/// <summary>
	/// List of all public methods of the service type.
	/// </summary>
	public IReadOnlyList<MethodSpecification> Methods { get; }
}
