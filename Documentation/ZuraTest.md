# `ZuraTest` attribute
If you want to, you can white your test using the `ZuraTest` attribute.

```csharp
using ZuraTDD;

[TestClass]
public partial class MyTests
{
	[ZuraTest<MyTestCase>("SendEmail succeeds when dependencies behave the expected way.")
	private ITestPart[] SendEmail_StandardBehaviors() => [
		Receives.SendEmail( ... ),
		
		When.CustomerRepository
			.GetCustomer()
			.ReturnsInTask((id, cancellationToken) => new Customer(id)),

		When.EmailSender
			.SendEmail()
			.Returns(Task.CompletedTask),
	];
}
```
