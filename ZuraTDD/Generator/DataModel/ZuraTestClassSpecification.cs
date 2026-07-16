using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Represents data used to generate code for a class decorated with <see cref="ZuraTestClass{TSubject}"/>.
/// </summary>
internal class ZuraTestClassSpecification
{
	/// <param name="testClassSymbol">Compilation symbol of the class decorated with [ZuraTestClass&lt;TSubject&gt;].</param>
	/// <param name="subjectType">The subject type extracted from the attribute's generic argument.</param>
	public ZuraTestClassSpecification(
		INamedTypeSymbol testClassSymbol,
		INamedTypeSymbol subjectType)
	{
		DecoratedClassNamespace = testClassSymbol.ContainingNamespace.ToDisplayString();
		DecoratedClassName = testClassSymbol.Name;
		TestSubject = new TestCaseSubject(subjectType);
		ImplicitTestCaseClass = new ImplicitTestCaseClass(subjectType);
	}

	public string DecoratedClassNamespace { get; }

	public string DecoratedClassName { get; }

	public TestCaseSubject TestSubject { get; }

	public ImplicitTestCaseClass ImplicitTestCaseClass { get; }
}
