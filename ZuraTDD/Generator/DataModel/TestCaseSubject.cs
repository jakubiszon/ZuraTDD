using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator.DataModel;

/// <summary>
/// Defines a class which is the subject of a test case. It could be one of:
/// <list type="bullet">
/// <item>Generic argument of a class inheriting <see cref="ITestCase{TSubject}" /></item>.
/// <item>Generic argument of <see cref="ZuraTestClass{TSubject}"/> decorating a test class.</item>
/// </list>
/// </summary>
internal class TestCaseSubject
{
	public string TestSubjectClassName { get; }

	public string DeclaringNamespace { get; }

	public string TestSubjectFullyQualifiedClassName { get; }

	/// <summary>
	/// Lists methods of the test subject which the system could potentially test.
	/// </summary>
	public IReadOnlyList<MethodSpecification> TestableMethods { get; }

	public DependenciesClassSpecification DependenciesClass { get; }

	public TestCaseSubject(INamedTypeSymbol testSubjectType)
	{
		TestSubjectClassName = testSubjectType.ToDisplayString();
		DeclaringNamespace = testSubjectType.ContainingNamespace.ToDisplayString();
		TestSubjectFullyQualifiedClassName = testSubjectType.ToDisplayString(
			SymbolDisplayFormat.FullyQualifiedFormat);

		TestableMethods = Functions.ExtractPublicMethods(testSubjectType);
		DependenciesClass = new DependenciesClassSpecification(testSubjectType);
		
	}
}
