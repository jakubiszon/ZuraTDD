# ZuraTDD - testing framework compatibility

ZuraTDD is a source generator and should generally not make your dependency management more difficult.
- It does not rely on any specific testing framework or library. In fact - this library itself is only referencing `Microsoft.CodeAnalysis.CSharp` and `Microsoft.CodeAnalysis.Analyzers`.
- It should be possible to use it alongside other mocking frameworks such as **NSubstitute** or **Moq** if you need them.
- It does not rely on **vstest** or **MSTest.Sdk** and will not force you to use either.
- It does not rely on any specific version of **.Net** or **.Net Framework** as long as the one you use is compatible with **netstandard2.0**.

## `ZuraTest` attribute limitations

There are some similations regarding the `ZuraTest` attribute. As the attribute is used to generate test methods - it needs to detect the test framework used and generate a correctly defined test. At the moment using this attribute will only work with the following frameworks:

- **MSTest**
- **XUnit**

More frameworks are planned to be added in the futre.

If your framework is not supported by the `ZuraTest` attribute. You can still use the library to generate:

- Classes marked with `ZuraTestClass<TSubject>` attribute.
- Manually mocked objects implementing `IMock<T>`.
- Manually creates test-case objects impplementing `ITestCase<T>`.

You will need to write the methods consuming the test-case objects. Here are some examples:
- [Passing a number of TestCase objects to a method consumig `DynamicData` in **MSTest**](https://github.com/jakubiszon/ZuraTDD/blob/main/ExampleProject.Tests/ContentPublishControllerTests.cs)
