namespace ExpenseTracker.Application.Ports;

public interface Clock
{
    public DateTime Now { get; }
}