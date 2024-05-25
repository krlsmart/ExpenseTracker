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

    public Task AddExpense(int amount)
        => repository.Store(ExpenseFrom(amount));

    public Task AddIncome(int amount)
        => repository.Store(IncomeFrom(amount));

    public Task<IEnumerable<Transaction>> RetrieveAllTransactions()
        => repository.RetrieveAll();
}