using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Infrastructure;
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
        var sut = new Account(repositoryMock);
        
        await sut.RetrieveAllTransactions();
        
        await repositoryMock.Received(1).RetrieveAll();
    }
    
    //TODO: Este test es bastante inutil. Borrar en cuanto se añada la bbdd real
    [Test]
    public async Task RetrieveAllExpenses_FromInMemoryRepository()
    {
        var sut = new Account(new InMemoryTransactionsRepository());

        await sut.AddExpense(100);
        await sut.AddExpense(500);
        var result = await sut.RetrieveAllTransactions();

        result.Should().HaveCount(2);
    }
}