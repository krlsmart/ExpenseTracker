using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class StoreExpenseFeature
{
    [Test]
    public void StoreExpense_WithAmount()
    {
        var repository = Substitute.For<ExpensesRepository>();
        var sut = new Tracker(repository);
        var expense = new Expense { Amount = 100 };

        sut.Store(expense);

        repository.Received(1).Store(Arg.Is<Expense>(e => e == expense));
    }
}