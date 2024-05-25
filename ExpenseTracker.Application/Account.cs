using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using static ExpenseTracker.Domain.TransactionFactory;

namespace ExpenseTracker.Application;

public class Account
{
    readonly TransactionsRepository repository;

    public Account(TransactionsRepository repository)
    {
        this.repository = repository;
    }

    public void AddExpense(int amount)
        => repository.Store(ExpenseFrom(amount));

    public void AddIncome(int amount)
        => repository.Store(IncomeFrom(amount));

    public IEnumerable<Transaction> RetrieveAllTransactions()
        => repository.RetrieveAll();
}