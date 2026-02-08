using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject;

internal interface ITemplateRepository
{
	Task<Template> GetTemplate(int templateId);
}
