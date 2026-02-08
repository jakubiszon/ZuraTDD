using System.Text.Json;

namespace ExampleProject;

/// <summary>
/// An abstraction defined to give an example of methods with same name and identical parameter names.
/// </summary>
public interface ITemplateParser
{
	Template? Parse( JsonDocument source );

	Template? Parse( TextReader source );
}
