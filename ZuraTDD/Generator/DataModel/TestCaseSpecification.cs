using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Represents data used to generate a test case using the test-case template.
/// </summary>
internal class TestCaseSpecification
{
	/// <param name="typeSymbol">Compilation symbol of the type defining the test case.</param>
	public TestCaseSpecification(INamedTypeSymbol typeSymbol)
	{
		var isInternal = typeSymbol.DeclaredAccessibility == Accessibility.Internal;

		var testSubjectType = typeSymbol.Interfaces.FirstOrDefault(Functions.ImplementsTestCaseInterface)
			?.TypeArguments[0] as INamedTypeSymbol
			?? throw new InvalidOperationException("Test case type does not implement ITestCase<T>");

		string testSubjectTypeName = testSubjectType.ToDisplayString();

		OutputNamespace = typeSymbol.ContainingNamespace.ToDisplayString();
		TestCaseClassName = typeSymbol.Name;
		TestSubjectClassName = testSubjectTypeName;
		TestSubjectFullyQualifiedClassName = testSubjectType.ToDisplayString(
			SymbolDisplayFormat.FullyQualifiedFormat);

		Methods = Functions.ExtractPublicMethods(testSubjectType);

		ServicesClass = new ServicesClassSpecification(
			OutputNamespace,
			testSubjectType);
	}

	public string OutputNamespace { get; set; } = string.Empty;

	public string TestCaseClassName { get; set; } = string.Empty;

	public string TestSubjectClassName { get; set; } = string.Empty;

	public string TestSubjectFullyQualifiedClassName { get; }

	public IReadOnlyList<MethodSpecification> Methods { get; set; }

	public ServicesClassSpecification ServicesClass { get; }
}
