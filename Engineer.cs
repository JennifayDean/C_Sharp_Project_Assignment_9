using System;
using System.Collections.Generic;

namespace Employees
{
	// Engineers have degrees
    public enum DegreeName { BS, MS, PhD }

    [System.Serializable]
    public class Engineer : Employee
    {
        #region Data members
        public DegreeName HighestDegree { get; set; } = DegreeName.BS;

        private static string prop1Name = "Degree:";
        #endregion

        #region Constructors 
        public Engineer() { }

		public Engineer(string firstName, string lastName, DateTime age, float currPay, string ssn, 
                        DegreeName degree)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the Engineer class.
            HighestDegree = degree;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Highest Degree: {0}", HighestDegree);
        }

        // Spare prop for degree
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Highest Degree:";
            propValue = HighestDegree.ToString();
        }

        public static string SpareAddProp1Name() { return prop1Name; }
        public static object SpareAddProp1DefaultValue() { return new List<String> { DegreeName.BS.ToString(), DegreeName.MS.ToString(), DegreeName.PhD.ToString() }; }

        public static object SpareAddProp1Convert(object obj)
        {
            return (DegreeName)obj;
        }
        #endregion
    }
}
