namespace ExpenseTracker.Domain;

public static class TransactionFactory
{
    public static Transaction ExpenseFrom(int amount) => new(-amount);
    public static Transaction IncomeFrom(int amount) => new(amount);
}