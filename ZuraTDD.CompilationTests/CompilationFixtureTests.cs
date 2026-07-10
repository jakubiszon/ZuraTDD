using Microsoft.CodeAnalysis;

namespace ZuraTDD.CompilationTests;

public class CompilationFixtureTests
{
	[Test]
	public void Compilation_ShouldNotHaveErrors()
	{
		if (CompilationFixture.Compilation == null)
		{
			Assert.Fail("Compilation is not initialized.");
		}

		var diagnostics = CompilationFixture.Compilation!.GetDiagnostics();
		var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error);
		if (errors.Any())
		{
			var errorMessages = string.Join(Environment.NewLine, errors.Select(e => e.ToString()));
			Assert.Fail($"Compilation has errors:{Environment.NewLine}{errorMessages}");
		}
	}

	[Test]
	public void TestNamespace_ShouldNotBeNull()
	{
		if (CompilationFixture.TestNamespace == null)
		{
			Assert.Fail("Test namespace is not initialized.");
		}
	}
}
