using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetTrackerAPI.Models
{
    public class BudgetTracker
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public void DeleteTransaction(int index)
        {
            if (index >= 0 && index < transactions.Count)
            {
                transactions.RemoveAt(index);
            }
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return transactions;
        }

        public decimal GetTotalIncome()
        {
            return transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
        }

        public decimal GetTotalExpenses()
        {
            return transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);
        }

        public decimal GetNetBalance()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }
    }
}
