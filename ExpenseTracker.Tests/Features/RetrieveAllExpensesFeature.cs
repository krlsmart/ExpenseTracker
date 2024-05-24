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
        var repositoryMock = Substitute.For<ExpensesRepository>();
        var sut = new Tracker(repositoryMock);

        sut.Store(new() { Amount = 100});
        sut.RetrieveAllExpenses();
        
        repositoryMock.Received(1).RetrieveAllExpenses();
    }
    
    [Test]
    public void RetrieveAllExpenses_FromInMemoryRepository()
    {
        var expense = new Expense { Amount = 100};
        var sut = new Tracker(new InMemoryExpensesRepository());

        sut.Store(expense);
        var result = sut.RetrieveAllExpenses();
        
        result.Should().HaveCount(1).And.Contain(expense);
    }
}