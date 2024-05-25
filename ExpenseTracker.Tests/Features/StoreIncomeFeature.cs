using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class StoreIncomeFeature
{
    [Test]
    public void StoreIncome_WithAmount()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = new Account(repositoryMock);

        sut.AddIncome(250);

        repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == 250));
    }
    
}