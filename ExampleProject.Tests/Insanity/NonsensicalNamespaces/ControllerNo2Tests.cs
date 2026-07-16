using ExampleProject.Insanity.NonsensicalNamespaces.Bar;
using ZuraTDD;

namespace ExampleProject.Tests.Insanity.NonsensicalNamespaces;

[TestClass]
[ZuraTestClass<ControllerInsideWeirdNamespace>]
public partial class BarControllerTests
{
}
