using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Application;

public class Account
{
    readonly TransactionsRepository repository;

    public Account(TransactionsRepository repository)
    {
        this.repository = repository;
    }

    public void AddExpense(Transaction transaction)
        => repository.Store(transaction);

    public IEnumerable<Transaction> RetrieveAllTransactions()
        => repository.RetrieveAll();
}