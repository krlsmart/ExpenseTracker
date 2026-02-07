namespace ExpenseTracker.Domain;

public record Transaction
{
    public int Amount { get; }
    public DateTime When { get; }

    public Transaction(int amount)
    {
        Amount = amount;
    }
    
    public Transaction(int amount, DateTime when) 
        : this(amount)
    {
        When = when;
    }
}