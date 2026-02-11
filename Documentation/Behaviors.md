# ZuraTDD - mock behaviors
*Behaviors* in short are the things that mocked objects do when their methods are called.

## Definitions
There are 3 types of behaviors:

- `Returns` - used to setup return values from mocked object methods.
- `Throws` - used to throw exceptions from mocked object methods.
- `Invokes` - especially useful when your mocked object receives a delegate which it needs to call.

Behaviors are chained into ***BehaviorSetup*** objects which also use [filter values](./CallMatching.md) to determine whether the specific setup should be used.

```csharp
// a declaration of a BehaviorSetup, filtering calls with tenantId == 1 and customerId > 0
// the chain contains all three behavior types.
setup.SomeMethod(
    tenantId: 123,
    customerId: new(id => i > 0))
    .Invokes(() => { /* some side effect */ })
    .Throws(new Exception())
    .Returns(new SomeObject());
```

## Getting behavior builders
You can aquire behavior builders in multiple ways:
- When using `Mock` objects - you get a `setup` object for your mocks:
  ```csharp
  // first you need to define what will be mocked
  internal partial class MyMock : IMock<IMyInterface>
  {
      // nothing more to do, mocking code will be generated
      // the class MyMock will be available in all tests
  }

  // then in test methods you can do:
  var (setup, buildInstance, buildExpect) = new MyMock();
  ```
- When using `TestCase` objects - you get named mock setup objects inside the `When` builder:
  ```csharp
  internal partial class MyTestCase : ITestCase<MyClass>
  {
      // nothing more to do, test-case code will be generated
  }

  // using static MyTestCase <- this is recommended to access "When" builder easily
  // in your test methods
  var testCase = new MyTestCase(
      // setup behaviors in MyTestCase constructor
      // "When" will contain named setup objecte of
      // all dependencies used by "MyClass"
      When....
  );
  ```

## Creating behaviors of the 3 types
`Invokes` behaviors can be constructed by passing a parameterless `Action` or an `Action` which takes perameters identical to the mocked method:
```csharp
setup.SomeMethod(
    tenantId: 123,
    customerId: new(id => i > 0))
    .Invokes(() => { /* some side effect */ })
    .Invokes((tId, cId) => { /* side effect consuming actual params */ });
```

`Returns` behaviors are constructed by accepting a value or a factory `Func` taking parameters identical to the mocked method:
```csharp
setup.SomeMethod(
    tenantId: 123,
    customerId: new(id => i > 0))
    .Returns(new SomeObject())
    .Returns((tId, cId) => new SomeObject(/*.....*/));
```

`Throws` behaviors are constructed by accepting an `Exception` value or an exception factory `Func`:
```csharp
setup.SomeMethod(
    tenantId: 123,
    customerId: new(id => i > 0))
    .Throws(new Exception())
    .Throws((tId, cId) => new Exception(/*.....*/));
```


## Rules governing BehaviorSetup execution
- A mocked method can be assigned any number of `BehaviorSetup` objects.
- These objects are executed in order of their declaration. Ones declared earlier are run first.
- A `BehaviorSetup` object is only executed if its filters match the values passed in the actual invocation.
- When a `BehaviorSetup` object is matched - all its `Invoke` behaviors are executed first regardless of their position in the chain. For that reason - it is recommended to call `.Invokes` funvtion before `.Throws` and `.Returns`. Future versions will report a compilation warning when the order is incorrect.
- The last declared `.Returns` or `.Throws` behavior on a chain will be repeated for all subsequent calls.
- `.Throws` and `.Returns` behaviors which are not declared as last in the chain will be executed once. Subsequent calls will execute the behaviors further in the chain.
- If `.Returns` or `.Throws` behavior is executed - the execution is finished. No further behaviors from the same `BehaviorSetup` will be executed. No further `BehaviorSetup` objects will be evaluated.


Let's look into an example:
```csharp
setup.GetStringById()
    .Invokes( SomeMethod );

setup.GetStringById(123)
    .Invokes( AnotherMethod )
    .Returns("example-123")
    .Throws(new Exception());

setup.GetStringById(new(x => x > 0))
    .Returns("example-greater-than-zero");

setup.GetStringById()
    .Throws(new ArgumentException("Value of the ID must be greater than 0."))
```

Calling `.GetStringBtyId` will execute the following:
- All calls to `.GetStringById` method will invoke `SomeMethod`. This will however not finish the execution of the mocked function.
- All calls with `id == 123` will invoke `AnotherMethod` before either returning or throwing.
- First call with `id == 123` will return `"example-123"`.
- All subsequent calls passing `123` will result in the exception being thrown.
- All calls where `id > 0` but different from `123` will return `"example-greater-than-zero"`.
- All other values will fall into the last `BehaviorSetup`. This setup accepts all values but the calls with positive `id` will never reach it because of the earlier setups.


## Best practices and recommendations
- If you need to use `.Invokes` - always declare it before `.Throws` and `.Returns`.
- Create `BehaviorSetup` object using the most specific filters first.
- Less specific filters should come next
- "Catch all" / unfiltered behavior should be created last.
- A non-filtering chain with an `.Invokes` behavior can be declared first. It can be useful if you have many setups declared but want all calls to invoke the same side-effect first.
