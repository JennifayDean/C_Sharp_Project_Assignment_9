using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Navigation;

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private EmployeeList empList = new EmployeeList();

        public MainWindow()
        {
            InitializeComponent();

            this.Closing += MainWindow_Closing;

            this.NavigationService.Navigate(new CompHome(empList));
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Save Employee list file
            SaveEmployeesAsBinary("Employees.dat", empList);
            
        }

        static void SaveEmployeesAsBinary(string fileName, List<Employee> emps)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(fileName,
                  FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, emps);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when saving employees: {0}", e.Message);
            }
        }
    }
}
