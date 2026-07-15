# Expectations

Expectations are used to verify if the tested method behaves as expected.
A single test can include multiple expectations. All of them are verified after the tested method completes. If any expectation fails, the test fails.

The `Expect` builder is used to specify expectations verified after the tested method is executed.

There are 3 kinds of expectations:
- **Method calls** - you can verify that a method was called with specific arguments and how many times it was called.
- **Exceptions** - you can verify that a specific exception was thrown from the tested method.
- **Return value** - you can verify that the tested method returned a specific value.

When all expectations pass the test succeeds. If any expectation fails an `ExpectationFailed` exception is thrown.

## Using Expect with `ZuraTestClass` or `ITestCase`

When using `ZuraTestClass` or `ITestCase`, the `Expect` static class is generated inside your test class or test case.
It exposes per-dependency expectation builders as well as built-in methods for exception and result expectations.

```csharp
[ZuraTestClass<ContentPublishedEventHandler>]
public partial class ContentPublishedEventHandlerTests
{
    [ZuraTest("Test name")]
    public ITestPart[] MyTest => [
        Receives.HandleContentPublish(exampleContent),

        When.EmailSender
            .SendEmail()
            .Returns(Task.CompletedTask),

        // verify a dependency method was called
        Expect.EmailSender
            .SendEmail(to: exampleCustomer.Email)
            .WasCalled(),

        // verify a dependency method was NOT called
        Expect.EmailSender
            .SendEmailSync()
            .WasNotCalled(),

        // verify the tested method returned a specific result
        Expect.ResultMatching<IActionResult>(result => result is OkObjectResult),
    ];
}

```

## Using Expect with `IMock<T>` directly

When using `IMock<T>` outside of a test case, you get an expect object from the `buildExpect` factory.
Verification happens immediately after each `.WasCalled()` / `.WasNotCalled()` call.

```csharp
// assuming MyMock is declared as implementing IMock<ISomeService>
var (setup, buildInstance, buildExpect) = new MyMock();

// ... set up behaviors and use the instance ...

var expect = buildExpect();
expect.SomeMethod().WasCalled();
expect.OtherMethod(arg: 42).WasNotCalled();
```


## Expecting method calls

The generated `Expect.{Dependency}` builders expose methods matching the mocked interface.
Each method returns an `ExpectedDependencyCallBuilder` which provides three termination methods:

| Method | Meaning |
|--------|---------|
| `.WasCalled()` | The method must have been called **at least once** with matching arguments. |
| `.WasCalled(int times)` | The method must have been called **exactly** `times` times with matching arguments. |
| `.WasNotCalled()` | The method must **not** have been called with matching arguments. |

### Matching parameters

Parameters use the same [value constraints](./CallMatching.md) as the `When` behavior builders.
You can skip any parameter to match any value, pass an exact value, or pass a predicate expression.

```csharp
// match any call to SendEmail - regardless of arguments
Expect.EmailSender
    .SendEmail()
    .WasCalled();

// match only calls where "to" contains an '@'
Expect.EmailSender
    .SendEmail(to: new(to => to.Contains('@')))
    .WasCalled();

// match only calls with a specific value
Expect.EmailSender
    .SendEmail(to: "bob@example.com")
    .WasCalled(1);
```

### Call count examples

```csharp
// at least one call
Expect.ContentBulkRepository
    .UpdateMany()
    .WasCalled();

// exactly one call
Expect.ContentBulkRepository
    .CommitTransaction()
    .WasCalled(1);

// must not have been called
Expect.EmailSender
    .SendEmailSync()
    .WasNotCalled();
```

### Generic method expectations

When the mocked interface has generic methods, you can specify the expected type arguments.
Use `GenericArgument.AnyType` to match any type argument.

```csharp
// verify DoSomething was called with int as the type argument
Expect.GenericMethods
    .DoSomething<int>()
    .WasCalled();

// verify DoSomething was NOT called with string
Expect.GenericMethods
    .DoSomething<string>()
    .WasNotCalled();

// verify DoSomething was not called regardless of generic type arguments used
Expect.GenericMethods
    .DoSomething<GenericArgument.AnyType>()
    .WasNotCalled();
```


## Expecting exceptions

Use `Expect.ExceptionToBeThrown<TException>()` to verify that the tested method threw a specific exception type.

```csharp
Expect.ExceptionToBeThrown<TestException>()
```

The verification follows these rules:
- If the tested method **did not throw** but an exception was expected, the expectation **fails**.
- If the tested method threw an exception of a **different type** than expected, the expectation **fails**.
- If the tested method threw an exception of the **expected type** (or a derived type), the expectation **passes**.

```csharp
[ZuraTest<ContentPublishedEventHandlerTestCase>(
    "Throws when CustomerRepository.ListByInterests throws.")]
public ITestPart[] ThrowsTest => [
    Receives.HandleContentPublish(exampleContent),

    When.CustomerRepository
        .ListByInterests()
        .Throws(new TestException()),

    Expect.ExceptionToBeThrown<TestException>()
];
```


## Expecting tested method result

Use `Expect.ResultMatching` or `Expect.ResultEqualTo` to verify the value returned by the tested method. If the method under test in `async` use the type that is returned inside the `Task<T>` or `ValueTask<T>` returned from the tested method.

### `ResultMatching<TResult>(Predicate<TResult>)`

Evaluates a predicate against the return value. The expectation fails if the predicate returns `false`.

```csharp
Expect.ResultMatching<IActionResult>(
    result => result is OkObjectResult)
```

### `ResultEqualTo<TResult>(TResult expectedValue)`

Checks equality against the expected value using `Equals`.

```csharp
Expect.ResultEqualTo<string>("expected value")
```

The verification follows these rules:
- If the return value **type does not match** `TResult`, the expectation **fails** with a type mismatch message.
- If the return value type matches but the **predicate returns false** (or equality check fails), the expectation **fails**.

```csharp
[ZuraTest("Returns BadRequest when content is null.")]
public ITestPart[] NullContentReturnsBadRequest => [
    Receives.PublishContent(content: null),

    Expect.ResultMatching<IActionResult>(
        result => result is BadRequestObjectResult),
];

[ZuraTest("Returns Ok when content is valid.")]
public ITestPart[] ValidContentReturnsOk => [
    Receives.PublishContent(content: BuildExampleContent()),

    Expect.ResultMatching<IActionResult>(
        result => result is OkObjectResult),
];
```
