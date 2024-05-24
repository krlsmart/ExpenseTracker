using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Application;

public class Tracker
{
    readonly ExpensesRepository repository;

    public Tracker(ExpensesRepository repository)
    {
        this.repository = repository;
    }

    public void Store(Expense expense)
        => repository.Store(expense);
}