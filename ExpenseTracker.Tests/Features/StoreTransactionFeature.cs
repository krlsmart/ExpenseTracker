using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class StoreTransactionFeature
{
    [Test]
    public async Task AddExpense()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        await sut.AddExpense(100);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == -100));
    }
    
    [Test]
    public async Task AddIncome()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        await sut.AddIncome(250);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == 250));
    }
}