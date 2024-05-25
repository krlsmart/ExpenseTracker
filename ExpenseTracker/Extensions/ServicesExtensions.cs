using ExpenseTracker.Application.Ports;
using ExpenseTracker.Infrastructure;

namespace ExpenseTracker.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddExpenseTrackerServices(this IServiceCollection services)
    {
        services.AddScoped<TransactionsRepository, InMemoryTransactionsRepository>();

        return services;
    }
}