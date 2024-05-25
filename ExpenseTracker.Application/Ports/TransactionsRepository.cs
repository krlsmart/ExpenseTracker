using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.Ports;

public interface TransactionsRepository
{
    public void Store(Transaction transaction);
    IEnumerable<Transaction> RetrieveAll();
}