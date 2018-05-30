using System;
using System.Collections.Generic;

namespace Employees
{
    public class EmployeeList : List<Employee>
    {
        public EmployeeList()
        {
            // Create Employees
            Manager Jane = new Manager("Jane", "Doe", DateTime.Parse("9/23/1991"), 10000);
            Employee Bob = new Employee("Bob", "Smith", DateTime.Parse("2/5/1972"));
            Employee Mike = new Employee("Mike", "Miller", DateTime.Parse("10/31/1975"));

            // Add Expenses
            Jane.Expenses.Add(new Expense(DateTime.Parse("1/25/2017"), ExpenseCategory.Travel, 300.55));
            Jane.Expenses.Add(new Expense(DateTime.Parse("1/27/2017"), ExpenseCategory.Meals, 27.61));
            Jane.Expenses.Add(new Expense(DateTime.Parse("1/29/2017"), ExpenseCategory.Lodging, 423.15));

            // Add Employees to List
            Add(Jane);
            Add(Bob);
            Add(Mike);
        }
    }
}
