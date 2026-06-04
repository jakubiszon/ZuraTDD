using System;
using System.Collections.Generic;
using System.Text;
using ExampleProject.Model;

namespace ExampleProject;

internal interface ITemplateRepository
{
	Task<Template> GetTemplate(int templateId);
}
