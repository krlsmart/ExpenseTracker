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

    [HttpGet(Name = "RetrieveAllExpenses")]
    public ActionResult<IEnumerable<Transaction>> RetrieveAllExpenses()
    {
        return Ok(account.RetrieveAllTransactions());
    }

    [HttpPost(Name = "StoreExpense")]
    public ActionResult<Transaction> StoreExpense(Transaction transaction)
    {
        account.AddExpense(transaction);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
}