using System;
using System.Collections.Generic;

namespace Employees
{
	// SupportPerson works a shift
    public enum ShiftName { One, Two, Three }

    [System.Serializable]
    public class SupportPerson : Employee
    {
        #region Data members
        public ShiftName Shift { get; set; } = ShiftName.One;

        private static string prop1Name = "Shift:";
        #endregion

        #region Constructors 
        public SupportPerson() { }

		public SupportPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, ShiftName shift)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the SupportPerson class.
            Shift = shift;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Shift: {0}", Shift);
		}

        // Spare prop for Shift
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Shift:";
            propValue = Shift.ToString();
        }

        public static string SpareAddProp1Name() { return prop1Name; }
        public static object SpareAddProp1DefaultValue() { return new List<String> { ShiftName.One.ToString(), ShiftName.Two.ToString(), ShiftName.Three.ToString() }; }
        #endregion
    }
}
