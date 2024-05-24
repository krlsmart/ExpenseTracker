using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.Ports;

public interface ExpensesRepository
{
    public void Store(Expense expense);
    IEnumerable<Expense> RetrieveAllExpenses();
}