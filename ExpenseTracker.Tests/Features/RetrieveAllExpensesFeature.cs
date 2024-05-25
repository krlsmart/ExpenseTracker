using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class RetrieveAllExpensesFeature
{
    [Test]
    public void RetrieveAllExpenses()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        sut.AddExpense(new() { Amount = 100});
        sut.RetrieveAllTransactions();
        
        repositoryMock.Received(1).RetrieveAll();
    }
    
    [Test]
    public void RetrieveAllExpenses_FromInMemoryRepository()
    {
        var expense = new Transaction { Amount = 100};
        var sut = new Account(new InMemoryTransactionsRepository());

        sut.AddExpense(expense);
        var result = sut.RetrieveAllTransactions();
        
        result.Should().HaveCount(1).And.Contain(expense);
    }
}