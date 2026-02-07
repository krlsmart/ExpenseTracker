using ExpenseTracker.Application.Ports;
using NSubstitute;

namespace ExpenseTracker.Application.Tests;

public static class BuilderFor
{
    public static Account Account(TransactionsRepository? repositoryMock = null, Clock? clockMock = null)
    {
        var repository = repositoryMock ?? Substitute.For<TransactionsRepository>();
        var clock = clockMock ?? Substitute.For<Clock>();
        return new Account(repository, clock);
    }
}