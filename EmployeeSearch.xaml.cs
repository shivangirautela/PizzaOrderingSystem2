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
using System.Windows.Shapes;
using PizzaOrderBLL;
using PizzaOrderCLasses;
using System.Configuration;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for EmployeeSearch.xaml
    /// </summary>
    public partial class EmployeeSearch : Window
    {
        EmployeeContext employeeContext;
        public EmployeeSearch()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EmployeeHomePage employeeHomePage = new EmployeeHomePage();
            employeeHomePage.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //show all customers orders
            this.datagrid2.ItemsSource = OrderContext.PopulateDataGridAllOrders();
            this.datagrid2.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //search customer by name 
            string nameOfCust = this.search_by_name.Text;
            this.employeeContext = new EmployeeContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
            
            List<Customer> requiredCustomer = this.employeeContext.DisplayCustomerSearch(nameOfCust);
            if (requiredCustomer.Count > 0)
            {
                this.datagrid1.ItemsSource = requiredCustomer;
            }
            else
            {
                this.datagrid1.Columns.Clear();
                MessageBox.Show("Sorry ! No Customers found with the matching name keywords.");
            }
        }
    }
}
