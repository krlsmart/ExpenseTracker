using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Infrastructure;

public class InMemoryTransactionsRepository : TransactionsRepository
{
    readonly List<Transaction> expenses = [];
    
    public Task Store(Transaction transaction)
    {
        expenses.Add(transaction);
        return Task.CompletedTask; 
    }

    public Task<IEnumerable<Transaction>> RetrieveAll()
        => Task.FromResult<IEnumerable<Transaction>>(expenses);
}