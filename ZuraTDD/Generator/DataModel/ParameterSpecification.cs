namespace ZuraTDD.Generator.DataModel;

internal class ParameterSpecification
{
	public string Type { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Type name to use in <see langword="typeof" /> expressions for this parameter.
	/// It may differ from <see cref="Type"/> for cases like nullable reference types.
	/// </summary>
	public string TypeofType { get; set; } = string.Empty;
}
