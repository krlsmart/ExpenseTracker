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
        var repository = Substitute.For<TransactionsRepository>();
        var sut = new Account(repository);
        var expense = new Transaction { Amount = 100 };

        sut.AddExpense(expense);

        repository.Received(1).Store(Arg.Is<Transaction>(e => e == expense));
    }
}