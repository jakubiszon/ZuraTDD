# ZuraTDD - matching method calls

ZuraTDD was designed to make parameter matching as simple as possible.
The generated mock-setup objects use method headers (almost) identical to those of the mocked objects.
The key differences are:

- You can skip any parameter you don't want to match - this results in the system matching any value used in the actual calls.
- The parameters use value constraint types - `ValueConstraint<T>`. This allows passing direct values or expressions which evaluate the value.

## Example
Let's consider a simple interface to mock:
```csharp
public interface ITemplateRepository
{
    Task<Template> Get( int id );

    Task<Template> Get( string name );

    Task Insert(
        string name,
        string body );

    Task Delete( int id );
}
```

ZuraTDD will generate a setup object with following methods<sup>1</sup>:
```csharp
Task<Template> Get( ValueConstraint<int>? id = null )

Task<Template> Get( ValueConstraint<string>? name = null )

Task Insert(
    ValueConstraint<string>? name = null,
    ValueConstraint<string>? body = null )

Task Delete( ValueConstraint<int>? id = null )
```

1. The actual method return types are more complex as they need to quote the exact input and output type parameters of the method. Here the original return types were shown to keep the example simple.


## Creating ValueConstraint objects
```csharp
// value types can be passed directly
setup.Delete(123)
    .Returns( Task.FromException( new Exception( "database error - template is referenced" )));

// skipping parameters will match all calls
setup.Delete()
    .Returns( Task.CompletedTask );

// passing an expression requires creating the ValueConstraint instance
// it can be writted very concisely if you use the latest language features:
setup.Delete( new( x => x < 0 ))
    .Returns( Task.FromException( new Exception( "the id must not be begative" )));
```

Note: The `.Returns` method used above is defining the [behavior](./Behaviors.md)
of the mocked method triggered when the call is matched.


## Ambiguous overloads
In the `ITemplateRepository` defined in the previous sections there are two `Get` methods.

```csharp
// skipping parameters when setting up Get would result in an ambiguous call
setup.Get() // this will NOT compile!
    .Returns( new Template() );

// passing a parameter name can help identifying the method
// you can pass a null to match all values
setup.Get(id: null)
    .Returns( new Template() );
```

Finally you can sometimes run into a method with same name and parameters of different types but identical names:
```csharp
public interface ITemplateParser
{
    Template? Parse( JsonDocument source );
    Template? Parse( TextReader source );
}
```

In this case the exact type of the param will have to be specified manually:
```csharp

setup.Parse( (ValueConstraint<JsonDocument>?)null )
    ... // behavior setup

setup.Parse( (ValueConstraint<TextReader>?)null )
    ... // behavior setup
```


## Matching `null`
Let's consider the following abstraction
```csharp
public interface IExample
{
    void ExampleMethod( SomeObject? someObject );
}
```

Passing `null` to a setup of `ExampleMethod` would result in all values of `SomeObject?` being accepted by the setup.
```csharp
// this will match ALL values - null and instances
setup.ExampleMethod( null )
    ... // behavior setup
```

If you need to create behavior matching a `null` you need to make sure the `null` is wrapped in a `ValueConstraint<>`.

```csharp
// you can cast the null to the type to match
setup.ExampleMethod( (SomeObject?)null )
    ... // behavior setup
```

You can also pass an expression which matches a `null`:
```csharp
// this will match null values
setup.ExampleMethod( new( someObject => someObject == null ))
    ... // behavior setup
```

Unfortunately calling `new( null )` would be ambiguous:
```csharp
// the following line is amboguous between the two constructors:
//   ValueConstrains<T>( T )
//   ValueConstrains<T>( Expression<Func<T>> )
setup.ExampleMethod( new( null ))
    ... // behavior setup
```

## Best practices and recommendations
- pass value types directly to avoid clutter
  ```csharp
  setup.Method( 10m ).Returns( ... );
  ```
- skip params which are not used to match calls
  ```csharp
  // catch all can skip all params
  setup.Method().Returns( ... );
  ```
- match null values by casting a null to your matched param type
  ```csharp
  setup.Method( (decimal?)null ).Returns( ... );
  ```

- when possible - use param names to distinguish ambiguous overloads
  ```csharp
  setup.GetInstance(name: null).Returns( ... );
  setup.GetInstance(id: null).Returns( ... );
  ```
- when overloads use the same parameter names - you will need to specify the types
  ```
  setup.Parse( (ValueConstraint<JsonDocument>?)null ).Returns( ... );
  setup.Parse( (ValueConstraint<TextReader>?)null ).Returns( ... );
  ```
