namespace ZuraTDD.Generator.DataModel;

internal class ParameterSpecification
{
	public string Type { get; set; } = string.Empty;

	/// <summary>
	/// Specifies whether the type of the parameter is a reference type.
	/// </summary>
	public bool IsReferenceType { get; set; }

	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Type name to use in <see langword="typeof" /> expressions for this parameter.
	/// It may differ from <see cref="Type"/> for cases like nullable reference types.
	/// </summary>
	// TODO: think of a better name
	public string TypeofType { get; set; } = string.Empty;
}
