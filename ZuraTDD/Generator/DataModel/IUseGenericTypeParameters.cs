using System.Collections.Generic;

namespace ZuraTDD.Generator.DataModel;

internal interface IUseGenericTypeParameters
{
	IReadOnlyCollection<GenericTypeParamSpecification> GenericTypeParameters { get; }
}
