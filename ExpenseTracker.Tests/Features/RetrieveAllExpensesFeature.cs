using ExpenseTracker.Application;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class RetrieveAllExpensesFeature
{
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