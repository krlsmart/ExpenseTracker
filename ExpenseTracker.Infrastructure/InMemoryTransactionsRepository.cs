using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Infrastructure;

public class InMemoryTransactionsRepository : TransactionsRepository
{
    readonly List<Transaction> expenses = [];
    
    public void Store(Transaction transaction)
        => expenses.Add(transaction);

    public IEnumerable<Transaction> RetrieveAll()
        => expenses;
}