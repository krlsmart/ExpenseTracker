using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Infrastructure;

public class InMemoryExpensesRepository : ExpensesRepository
{
    readonly List<Expense> expenses = [];
    
    public void Store(Expense expense)
        => expenses.Add(expense);

    public IEnumerable<Expense> RetrieveAllExpenses()
        => expenses;
}