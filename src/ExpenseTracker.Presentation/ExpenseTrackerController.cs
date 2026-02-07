using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ExpenseTrackerController(TransactionsRepository repository, Clock clock) : ControllerBase
{
    readonly Account account = new(repository, clock);

    [HttpGet("RetrieveAllTransactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> RetrieveAllTransactions()
    {
        var allTransactions = await account.RetrieveAllTransactions();
        return Ok(allTransactions);
    }

    [HttpPost("AddExpense")]
    public async Task<ActionResult<Transaction>> AddExpense(int amount)
    {
        await account.CreateAndStoreExpense(amount);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
    
    [HttpPost("AddIncome")]
    public async Task<ActionResult<Transaction>> AddIncome(int amount)
    {
        await account.CreateAndStoreIncome(amount);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
}