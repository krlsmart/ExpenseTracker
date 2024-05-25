using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using NSubstitute;

namespace ExpenseTracker.Tests.TestApi;

public static class BuilderFor
{
    public static Account Account(TransactionsRepository repositoryMock = null, Clock clockMock = null)
    {
        var repository = repositoryMock ?? Substitute.For<TransactionsRepository>();
        var clock = clockMock ?? Substitute.For<Clock>();
        return new(repository, clock);
    }
}