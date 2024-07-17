using System;

namespace BudgetTrackerAPI.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }

        public Transaction(DateTime date, string description, decimal amount, bool isIncome)
        {
            Date = date;
            Description = description;
            Amount = amount;
            IsIncome = isIncome;
        }

        public override string ToString()
        {
            string type = IsIncome ? "Income" : "Expense";
            return $"{Date.ToShortDateString()} - {Description} - {type}: {Amount:C}";
        }
    }
}
