using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Employee
    {
        public static int NamespaceLength = 10;

        static int NextId = 1;
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DOB { get; }
        public string Name { get { return FirstName + " " + LastName; } }
        public virtual string Role { get { return GetType().ToString().Substring(10); } }
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        public Employee() { }
        public Employee(string firstName, string lastName, DateTime dateOfBirth)
        {
            Id = Employee.NextId++;
            FirstName = firstName;
            LastName = lastName;
            DOB = dateOfBirth;
        }

        // Details spare prop
        public virtual void GetSpareProp1(ref string name, ref string value) { }
    }
}
