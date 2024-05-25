namespace ExpenseTracker.Domain;

public record Transaction
{
    public int Amount { get; }

    public Transaction(int amount)
    {
        Amount = amount;
    }
}