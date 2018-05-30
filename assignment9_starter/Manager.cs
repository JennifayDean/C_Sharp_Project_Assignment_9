using System;

namespace Employees
{
    public class Manager : Employee
    {
        public int StockOptions { get; } = 100;

        // Spare prop data
        private static string prop1Name = "Stock Options:";
        private static object prop1DefaultValue = 500;

        public Manager() { }
        public Manager(string firstName, string lastName, DateTime dateOfBirth, int stockOptions)
            : base(firstName, lastName, dateOfBirth)
        {
            StockOptions = stockOptions;
        }

        // Details spare prop
        public override void GetSpareProp1(ref string name, ref string value)
        {
            name = prop1Name;
            value = StockOptions.ToString();
        }

        // Add Employee spare props
        public static string SpareAddProp1Name() { return prop1Name; }
        public static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        // Convert passed value to a valid value
        public static object SpareAddProp1Convert(object obj)
        {
            if (obj is int) return obj;
            else if (obj is string)
            {
                string s = (string)obj;
                int value;

                if (int.TryParse(s, out value)) return value;
            }

            return -1;
        }

        // Return error message if there is error 
        // else return String.Empty
        public static string SpareAddProp1Valid(object obj)
        {
            if (obj is string)
            {
                string s = (string)obj;
                int value;

                if (int.TryParse(s, out value) && value >= 0 && value <= 10000)
                    return String.Empty;
            }

            return "Range is 0 to 100,000";
        }
    }
}
