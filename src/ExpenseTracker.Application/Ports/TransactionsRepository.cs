using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.Ports;

public interface TransactionsRepository
{
    public Task Store(Transaction transaction);
    Task<IEnumerable<Transaction>> RetrieveAll();
}