using ExampleProject.Insanity;
using ZuraTDD;

namespace ExampleProject.Tests;

internal partial class EmailSenderMock : IMock<IEmailSender>
{
}

internal partial class TemplateParserMock : IMock<ITemplateParser>
{
}

internal partial class AcceptNullMock : IMock<IAcceptNull>
{
}

internal partial class ActionServiceMock : IMock<IActionService>
{
}

internal partial class FuncServiceMock : IMock<IFuncService>
{
}

internal partial class AsyncMethodsMock : IMock<IAsyncMethods>
{
}
