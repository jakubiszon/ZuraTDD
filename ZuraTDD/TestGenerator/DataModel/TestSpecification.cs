using Microsoft.CodeAnalysis;
using ZuraTDD.Generator.DataModel;

namespace ZuraTDD.TestGenerator.DataModel;

/// <summary>
/// Specification of a test to generate.
/// </summary>
internal class TestSpecification
{
	/// <summary>
	/// Name of the namespace containing the type receiving the generated test-method.
	/// </summary>
	public string OutputNamespace { get; }

	/// <summary>
	/// Name of the partial class which will receive the generated test-method.
	/// </summary>
	public string OutputTypeName { get; }

	/// <summary>
	/// Name of the property or method decorated with the <see cref="ZuraTest"/>.
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

	public string OutputFileName => $"{OutputNamespace}.{OutputTypeName}_{TestPartSourceName}.test.generated.cs";

	public TestFramework TestFramework { get; }

	public ImplicitTestCaseClass ImplicitTestCaseClass { get; }

	public TestSpecification(
		IMethodSymbol methodSymbol,
		AttributeData attributeData,
		TestFramework testFramework,
		ImplicitTestCaseClass implicitTestCaseClass)
	{
		TestName = attributeData.ConstructorArguments[0].Value as string ?? "Unnamed test";
		OutputNamespace = methodSymbol.ContainingNamespace.ToDisplayString();
		OutputTypeName = methodSymbol.ContainingType.Name;
		TestPartSourceName = methodSymbol.Name;
		IsSourceMethod = true;
		TestFramework = testFramework;
		ImplicitTestCaseClass = implicitTestCaseClass;
	}

	public TestSpecification(
		IPropertySymbol propertySymbol,
		AttributeData attributeData,
		TestFramework testFramework,
		ImplicitTestCaseClass implicitTestCaseClass)
	{
		TestName = attributeData.ConstructorArguments[0].Value as string ?? "Unnamed test";
		OutputNamespace = propertySymbol.ContainingNamespace.ToDisplayString();
		OutputTypeName = propertySymbol.ContainingType.Name;
		TestPartSourceName = propertySymbol.Name;
		IsSourceMethod = false;
		TestFramework = testFramework;
		ImplicitTestCaseClass = implicitTestCaseClass;
	}
}
