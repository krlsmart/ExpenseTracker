using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using ExpenseTracker.Tests.TestApi;
using FluentAssertions.Extensions;
using NSubstitute;
using NUnit.Framework;

namespace ExpenseTracker.Tests.Features;

public class StoreTransactionFeature
{
    [Test]
    public async Task AddExpense()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);

        await sut.CreateAndStoreExpense(100);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == -100));
    }
    
    [Test]
    public async Task AddIncome()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);

        await sut.CreateAndStoreIncome(250);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == 250));
    }
}