using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees
{
    public partial class MainWindow : NavigationWindow
    {
        #region Data members
        private EmployeeList empList = new EmployeeList();
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            // Catch closing event to save changes
            this.Closing += MainWindow_Closing;

            // Create Details page and navigate to page
            this.NavigationService.Navigate(new CompHome(empList));
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        // Good place to save EmployeeList to file
        }
        #endregion
    }
}
