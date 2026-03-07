using Microsoft.CodeAnalysis;

namespace ZuraTDD.TestGenerator.DataModel;

/// <summary>
/// Specifies an error to emit or a test to generate.
/// Note that both the <see cref="DiagnosticMessage" /> and the <see cref="TestSpecification"/>
/// can be <see langword="null"/> - in such case nothing is generated.
/// </summary>
internal class ZuraTestAnalysis
{
	/// <summary>
	/// Specifies a diagnostic message to emit. If this is not <see langword="null"/>, no test will be generated.
	/// </summary>
	public Diagnostic? DiagnosticMessage { get; }

	/// <summary>
	/// Specifies a test to generate.
	/// </summary>
	public TestSpecification? TestSpecification { get; }

	/// <summary>
	/// Creates a result which does not specify an error or a test to generate.
	/// </summary>
	public ZuraTestAnalysis()
	{
		DiagnosticMessage = null;
		TestSpecification = null;
	}

	/// <summary>
	/// Creates a result which specifies a compilation error.
	/// </summary>
	public ZuraTestAnalysis(Diagnostic diagnosticMessage)
	{
		DiagnosticMessage = diagnosticMessage;
		TestSpecification = null;
	}

	/// <summary>
	/// Creates a result which specifies a test to generate.
	/// </summary>
	public ZuraTestAnalysis(TestSpecification testSpecification)
	{
		DiagnosticMessage = null;
		TestSpecification = testSpecification;
	}
}
