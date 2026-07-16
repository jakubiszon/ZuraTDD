using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Represents data used to generate code for a user-defined test-case class
/// implementing <see cref="ITestCase{TSubject}"/> for a specific subject type.
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

		OutputNamespace = typeSymbol.ContainingNamespace.ToDisplayString();
		TestCaseClassName = typeSymbol.Name;
		TestSubject = new TestCaseSubject(testSubjectType);
	}

	public string OutputNamespace { get; set; } = string.Empty;

	public string TestCaseClassName { get; set; } = string.Empty;

	public TestCaseSubject TestSubject { get; }
}
