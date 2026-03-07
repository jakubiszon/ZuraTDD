using Microsoft.CodeAnalysis;

namespace ZuraTDD.TestGenerator.DataModel;

/// <summary>
/// Specification of a test to generate.
/// </summary>
internal class TestSpecification
{
	/// <summary>
	/// Name of the namespace containing the type receiving the generatyed code.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Name of the partial class which will receive the generated test method.
	/// </summary>
	public string OutputTypeName { get; }

	/// <summary>
	/// Name of the property or method decorated with the <see cref="ZuraTest{T}"/>.
	/// </summary>
	public string TestPartSourceName { get; }

	/// <summary>
	/// Specifies whether the source of the test parts is a method.
	/// When this is <see langword="false"/>, the source is a property.
	/// </summary>
	public bool IsSourceMethod { get; }

	/// <summary>
	/// Name to include as the display name of the generated test method in the test explorer.
	/// </summary>
	public string TestName { get; }

	public string OutputFileName => $"{OutputTypeName}_{TestPartSourceName}.test.generated.cs";

	/// <summary>
	/// Name of the type referenced in the <see cref="ZuraTest{T}"/> attribute.
	/// </summary>
	public string TestCaseClassName { get; }

	public TestSpecification(
		IMethodSymbol methodSymbol,
		AttributeData attributeData)
	{
		TestName = attributeData.ConstructorArguments[0].Value as string ?? "Unnamed test";
		OutputNamespace = methodSymbol.ContainingNamespace.ToDisplayString();
		OutputTypeName = methodSymbol.ContainingType.Name;
		TestPartSourceName = methodSymbol.Name;
		IsSourceMethod = true;

		TestCaseClassName = attributeData
			.AttributeClass
			?.TypeArguments[0]
			.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining))
			?? "UnknownTestCase";
	}

	public TestSpecification(
		IPropertySymbol propertySymbol,
		AttributeData attributeData)
	{
		TestName = attributeData.ConstructorArguments[0].Value as string ?? "Unnamed test";
		OutputNamespace = propertySymbol.ContainingNamespace.ToDisplayString();
		OutputTypeName = propertySymbol.ContainingType.Name;
		TestPartSourceName = propertySymbol.Name;
		IsSourceMethod = false;

		TestCaseClassName = attributeData
			.AttributeClass
			?.TypeArguments[0]
			.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining))
			?? "UnknownTestCase";
	}
}
