using ExpenseTracker.Application.Ports;

namespace ExpenseTracker.Infrastructure;

public class SystemClock : Clock
{
    public DateTime Now => DateTime.Now;
}