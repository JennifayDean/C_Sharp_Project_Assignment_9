﻿using System;

namespace Employees
{
    // Salespeople need to know their number of sales.
    [System.Serializable]
    class SalesPerson : Employee
    {
        #region Data members
        public int SalesNumber { get; set; }

        private static string prop1Name = "Sales:";
        private static object prop1DefaultValue = 0;
        #endregion

        #region Constructors 
        public SalesPerson() { }

        // Subclasses should explicitly call an appropriate base class constructor.
        public SalesPerson(string firstName, string lastName, DateTime age, float currPay, 
                           string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This belongs with us!
            SalesNumber = numbOfSales;
        }
        #endregion

        #region Class methods
        // A salesperson's bonus is influenced by the number of sales.
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

        // A SalesPerson gets an extra 300 on promotion
        public override sealed void GivePromotion()
        {
            base.GivePromotion();
            GiveBonus(300);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of sales: {0:N0}", SalesNumber);
        }

        // Spare prop for sales
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Sales Number:";
            propValue = SalesNumber.ToString();
        }

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
        #endregion
    }
}
