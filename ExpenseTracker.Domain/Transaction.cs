namespace ExpenseTracker.Domain;

public record Transaction
{
    public int Amount { get; init; }
}