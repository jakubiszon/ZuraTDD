using System;
using Microsoft.CodeAnalysis;

namespace ZuraTDD.Generator;

/// <summary>
/// An object defining either a file to emit or a diagnostic to report during source generation.
/// Only one property will be set to not-null.
/// </summary>
internal class SourceFileOrDiagnostic
{
	public SourceFileToGenerate? SourceFile { get; }

	public Diagnostic? Diagnostic { get; }

	public SourceFileOrDiagnostic(SourceFileToGenerate sourceFile)
	{
		SourceFile = sourceFile ?? throw new ArgumentNullException(nameof(sourceFile));
	}

	public SourceFileOrDiagnostic(Diagnostic diagnostic)
	{
		Diagnostic = diagnostic ?? throw new ArgumentNullException(nameof(diagnostic));
	}
}
