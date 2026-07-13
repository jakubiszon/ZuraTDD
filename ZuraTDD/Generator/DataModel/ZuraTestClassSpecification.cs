using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

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
		OutputNamespace = testClassSymbol.ContainingNamespace.ToDisplayString();
		DecoratedClassName = testClassSymbol.Name;
		TestSubjectClassName = subjectType.ToDisplayString();
		TestSubjectFullyQualifiedClassName = subjectType.ToDisplayString(
			SymbolDisplayFormat.FullyQualifiedFormat);

		TestCaseClassName = $"{subjectType.Name}TestCase";

		TestableMethods = Functions.ExtractPublicMethods(subjectType);

		DependenciesClass = new DependenciesClassSpecification(
			OutputNamespace,
			subjectType);
	}

	public string OutputNamespace { get; }

	public string DecoratedClassName { get; }

	public string TestSubjectClassName { get; }

	public string TestSubjectFullyQualifiedClassName { get; }

	/// <summary>
	/// Name of the implicit TestCase class generated for the subject type.
	/// Convention: {SubjectTypeName}TestCase
	/// </summary>
	public string TestCaseClassName { get; }

	/// <summary>
	/// Lists methods of the test subject which the system could potentially test.
	/// </summary>
	public IReadOnlyList<MethodSpecification> TestableMethods { get; }

	public DependenciesClassSpecification DependenciesClass { get; }
}
