using BudgetTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BudgetTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetTrackerController : ControllerBase
    {
        private static BudgetTracker tracker = new BudgetTracker();

        [HttpGet("transactions")]
        public IEnumerable<Transaction> GetTransactions()
        {
            return tracker.GetTransactions();
        }

        [HttpPost("add")]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            tracker.AddTransaction(transaction);
            return Ok();
        }

        [HttpDelete("delete/{index}")]
        public IActionResult DeleteTransaction(int index)
        {
            tracker.DeleteTransaction(index);
            return Ok();
        }

        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var summary = new
            {
                TotalIncome = tracker.GetTotalIncome(),
                TotalExpenses = tracker.GetTotalExpenses(),
                NetBalance = tracker.GetNetBalance()
            };
            return Ok(summary);
        }
    }
}
