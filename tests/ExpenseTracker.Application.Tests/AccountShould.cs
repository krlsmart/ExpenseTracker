using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure;
using NSubstitute;

namespace ExpenseTracker.Application.Tests;

public class AccountShould
{
    [Fact]
    public async Task RetrieveAllExpenses()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);
        
        await sut.RetrieveAllTransactions();
        
        await repositoryMock.Received(1).RetrieveAll();
    }
    
    //TODO: Este test es bastante inutil. Borrar en cuanto se añada la bbdd real
    [Fact]
    public async Task RetrieveAllExpenses_FromInMemoryRepository()
    {
        var sut = BuilderFor.Account(new InMemoryTransactionsRepository());

        await sut.CreateAndStoreExpense(100);
        await sut.CreateAndStoreExpense(500);
        var result = await sut.RetrieveAllTransactions();

        Assert.Equal(2, result.Count());
    }
    
    [Fact]
    public async Task AddExpense()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);

        await sut.CreateAndStoreExpense(100);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == -100));
    }
    
    [Fact]
    public async Task AddIncome()
    {
        var repositoryMock = Substitute.For<TransactionsRepository>();
        var sut = BuilderFor.Account(repositoryMock);

        await sut.CreateAndStoreIncome(250);

        await repositoryMock.Received(1).Store(Arg.Is<Transaction>(t => t.Amount == 250));
    }
}