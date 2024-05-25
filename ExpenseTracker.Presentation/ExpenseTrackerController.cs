using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ExpenseTrackerController(TransactionsRepository repository) : ControllerBase
{
    readonly Account account = new(repository);

    [HttpGet("RetrieveAllTransactions")]
    public ActionResult<IEnumerable<Transaction>> RetrieveAllTransactions()
    {
        return Ok(account.RetrieveAllTransactions());
    }

    [HttpPost("AddExpense")]
    public ActionResult<Transaction> AddExpense(int amount)
    {
        account.AddExpense(amount);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
    
    [HttpPost("AddIncome")]
    public ActionResult<Transaction> AddIncome(int amount)
    {
        account.AddIncome(amount);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
}