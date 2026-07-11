using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace ZuraTDD.CompilationTests;

[TestClass]
public class CompilationFixture
{
	internal static CSharpCompilation? Compilation { get; private set; } = null;

	/// <summary>
	/// The symbol containing the namespace defined in Test.cs.txt file.
	/// </summary>
	internal static INamespaceSymbol? TestNamespace { get; private set; } = null;

	[AssemblyInitialize]
    public static void RunBeforeAnyTests(TestContext context)
    {
		var sourceCode = File.ReadAllText("Test.cs.txt");

		SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

        var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            .WithSpecificDiagnosticOptions(new Dictionary<string, ReportDiagnostic>
            {
                { "CS8019", ReportDiagnostic.Suppress } // Suppress unused using warnings
            });

		Compilation = CSharpCompilation.Create("Analysis")
			.WithOptions(compilationOptions)
			.AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
			.AddSyntaxTrees(syntaxTree);

		TestNamespace = FindNamespace(Compilation, "MyApp");
    }

    [AssemblyCleanup]
    public static void RunAfterAnyTests()
    {
		// actually there is nothing to dispose
    }

	private static INamespaceSymbol? FindNamespace(CSharpCompilation compilation, string name)
	{
		foreach (var @namespace in compilation.GlobalNamespace.GetNamespaceMembers())
		{
			if(@namespace.Name == name)
			{
				return @namespace;
			}
		}

		return null;
	}

	internal static INamedTypeSymbol? GetNamedType(string typeName)
	{
		return TestNamespace!
			.GetMembers(typeName)
			.OfType<INamedTypeSymbol>()
			.FirstOrDefault();
	}
}
