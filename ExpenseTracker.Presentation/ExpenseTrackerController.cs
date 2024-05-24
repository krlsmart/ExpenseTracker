﻿using ExpenseTracker.Application;
using ExpenseTracker.Application.Ports;
using ExpenseTracker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ExpenseTrackerController(ExpensesRepository repository) : ControllerBase
{
    readonly Tracker tracker = new(repository);

    [HttpGet(Name = "RetrieveAllExpenses")]
    public ActionResult<IEnumerable<Expense>> RetrieveAllExpenses()
    {
        return Ok(tracker.RetrieveAllExpenses());
    }

    [HttpPost(Name = "StoreExpense")]
    public ActionResult<Expense> StoreExpense(Expense expense)
    {
        tracker.Store(expense);

        //Habría que devolver un CreatedAtAction por convenio
        //pero no tengo todavía manera de obtener concretamente el recurso creado
        return Ok();
    }
}