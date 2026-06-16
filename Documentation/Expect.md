# Expectations

The `Expect` builder is used to specify expectations verified after the tested method is executed.

There are 3 kinds of expectations:
- **Method calls** - you can verify that a method was called with specific arguments and how many times it was called.
- **Exceptions** - you can verify that a specific exception was thrown from the tested method.
- **Return value** - you can verify that the tested method returned a specific value.

When you use `IMock<T>` directly, you can build expect object related to the mocked interface
```csharp
var (setup, buildInstance, buildExpect) = new MyMock();

// after building and using the instance
var expect = buildExpect();
expect.SomeMethod().WasCalled();
```


## Expecting method calls
