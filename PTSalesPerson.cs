using System;

namespace Employees
{
    [System.Serializable]
    sealed class PTSalesPerson : SalesPerson
    {
        #region Constructors
        public PTSalesPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn, numbOfSales)
        {
        }
        #endregion

        private static string prop1Name = "Sales:";
        private static object prop1DefaultValue = 0;
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
