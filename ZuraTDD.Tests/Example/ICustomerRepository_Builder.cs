using System;
using System.Collections.Generic;
using System.Text;

namespace ZuraTDD.Tests.Example;

/// <summary>
/// Instance builder of <see cref="ExampleProject.ICustomerRepository" />.
/// </summary>
internal class ICustomerRepository_Builder
	: ICustomerRepository_BehaviorBuilder
	, IBuild<ICustomerRepository_Fake>
{
	public ICustomerRepository_Builder()
		: base(new BehaviorSetupCollector())
	{
	}

	public ICustomerRepository_Fake BuildInstance()
	{
		var collector = base.behaviorSetupProcessor as BehaviorSetupCollector;

		return new(
			collector!.BuildSetupCollection());
	}
}
