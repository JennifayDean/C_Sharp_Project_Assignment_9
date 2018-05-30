using System;

namespace Employees
{
    public enum ExpenseCategory { Conference, Lodging, Meals, Misc, Travel }

    [Serializable]
    public class Expense
    {
        #region Data members / properties
        public DateTime Date { get; set; } = DateTime.Today;
        public ExpenseCategory Category { get; set; }
        public double Amount { get; set; }
        #endregion

        #region Constructors
        public Expense() { }

        public Expense(DateTime expDate, ExpenseCategory category, double amount)
        {
            Date = expDate;
            Category = category;
            Amount = amount;
        }
        #endregion
    }
}
