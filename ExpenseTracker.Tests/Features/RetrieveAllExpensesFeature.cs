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
        
        sut.RetrieveAllTransactions();
        
        repositoryMock.Received(1).RetrieveAll();
    }
    
    [Test]
    public void RetrieveAllExpenses_FromInMemoryRepository()
    {
        var sut = new Account(new InMemoryTransactionsRepository());

        sut.AddExpense(100);
        sut.AddExpense(500);
        var result = sut.RetrieveAllTransactions();

        result.Should().HaveCount(2);
    }
}