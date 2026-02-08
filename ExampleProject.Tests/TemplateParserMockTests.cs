using System.Text.Json;
using ZuraTDD;

namespace ExampleProject.Tests;

[TestClass]
public class TemplateParserMockTests
{
	[TestMethod]
	public void CallingMockedOverloads_Compiles()
	{
		var (setup, buildInstance, buildExpect) = new TemplateParserMock();

		setup.Parse((ValueConstraint<JsonDocument>?)null)
			.Returns((Template?)null);

		setup.Parse((ValueConstraint<TextReader>?)null)
			.Returns((Template?)null);
	}
}
