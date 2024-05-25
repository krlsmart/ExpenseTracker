using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class StoreTransactionFeature
{
    [Test]
    public void AddExpense()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        sut.AddExpense(100);

        repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == -100));
    }
    
    [Test]
    public void AddIncome()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        sut.AddIncome(250);

        repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == 250));
    }
}