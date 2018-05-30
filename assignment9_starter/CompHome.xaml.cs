// CSD 228 - Assignment 9 Help
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Employees
{
    public partial class CompHome : Page
    {
        #region Data members
        static EmployeeList empList;
        #endregion

        #region Constructors
        public CompHome()
        {
            InitializeComponent();
        }

        public CompHome(EmployeeList emps) : this()
        {
            empList = emps;

            // Select the All radio button
            this.EmployeeTypeRadioButtons.SelectedIndex = 0;

            // Set event handler for radio button changes
            this.EmployeeTypeRadioButtons.SelectionChanged += new SelectionChangedEventHandler(EmployeeTypeRadioButtons_SelectionChanged);

            // Fill the Employees data grid
            dgEmps.ItemsSource = empList;
        }
        #endregion

        #region Class methods and event handlers
        // Button clicks
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            // Show Employee details if one selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompDetails(this.dgEmps.SelectedItem));
            }
        }

        private void Details_DoubleClick(object sender, RoutedEventArgs e)
        {
            // Show Employee details if one selected
            this.NavigationService.Navigate(new CompDetails(this.dgEmps.SelectedItem));
        }

        private void Expenses_Click(object sender, RoutedEventArgs e)
        {
            // Show Employee details if one selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompExpenses(this.dgEmps.SelectedItem));
            }
        }

        // Handle Add employee button click
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CompAddEmployee(this, empList));
        }

        // Handle changes to Employee type radio buttons
        void EmployeeTypeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeeList();
        }

        // Filter Employee list according to radio button setting
        public void RefreshEmployeeList()
        {
            List<Employee> empList1;

            // Apply the selection - All or Manager
            switch (this.EmployeeTypeRadioButtons.SelectedIndex)
            {
                // Executives
                case 1:
                    empList1 = (List<Employee>)empList.FindAll(obj => obj is Manager);
                    break;

                // All 
                default:
                    empList1 = empList;
                    break;
            }

            dgEmps.ItemsSource = new ObservableCollection<Employee>(empList1);

            dgEmps.Items.Refresh();
        }

        #endregion
    }
}
