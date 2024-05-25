using ExpenseTracker.Application.Ports;
using ExpenseTracker.Infrastructure;
using ExpenseTracker.Tests.TestApi;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class RetrieveAllExpensesFeature
{
    [Test]
    public async Task RetrieveAllExpenses()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);
        
        await sut.RetrieveAllTransactions();
        
        await repositoryMock.Received(1).RetrieveAll();
    }
    
    //TODO: Este test es bastante inutil. Borrar en cuanto se añada la bbdd real
    [Test]
    public async Task RetrieveAllExpenses_FromInMemoryRepository()
    {
        var sut = BuilderFor.Account(new InMemoryTransactionsRepository());

        await sut.CreateAndStoreExpense(100);
        await sut.CreateAndStoreExpense(500);
        var result = await sut.RetrieveAllTransactions();

        result.Should().HaveCount(2);
    }
}