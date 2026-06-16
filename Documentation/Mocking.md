# Mocking

In some cases it is useful to create mocked dependencies instead of relying on `ITestCase`.
To give an example - when a method you mock needs to return a mocked object and the returned
object is them used by the tested method.

To give an example of such case - let's imagine a class `CompanyDataService`
which will use `ITransactionManager` to manage 

```csharp
public class CompanyDataService(
    ITransactionManager transactionManager,
    ICompanyRepository companyRepository,
    IPersonRepository personRepository)
{
    public Task CreateCompany(Company company)
    {
        // start a transaction
        using var transaction = transactionManager.BeginTransaction();
        try
        {
            var companyTask = companyRepository.InsertCompany(company);
            var personTask = personRepository.FindOrInsert(company.Employees);

            var companyId = await companyTask;
            var personIds = await Task.WhenAll(personTasks);

            await companyRepository.AssignEmployees(companyId, personIds);

            await transaction.Commit();
        }
        catch
        {
            await transaction.Rollback();
            throw;
        }
    }
}
```

To test the method, we will need to return a transaction object.
Let's assume the transaction is using the following interface:

```csharp
public interface ITransaction : IAsyncDisposable
{
    Task Commit();
    Task Rollback();
}
```

In order to simplify setting up a mocked transaction, we can tell the system to generate a mock-builder:
```csharp
public partial class TransactionMock : IMock<ITransaction>
{
    // note that this class needs to be partial
    // no code is required inside it
}
```

In the tests, we will be able to use it like this:

```csharp
[ZuraTest<CompanyDataServiceTestCase>("test description")]
public ITestPart[] HappyPath()
{
    var (setup, buildInstance, buildExpect) = new TransactionMock();
    var transaction = buildInstance();

    return [
        When.TransactionManager
            .BeginTransaction()
            .Returns(transaction),

        When.CompanyRepository
            .InsertCompany()
            .ReturnsInTask(Guid.NewGuid()),

        When.PersonRepository
            .FindOrInsert()
            .ReturnsInTask(Guid.NewGuid()),

        When.CompanyRepository
            .AssignEmployees()
            .ReturnsInTask(),
    ];
}
```
