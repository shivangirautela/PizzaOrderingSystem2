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

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for EmployeeHomePage.xaml
    /// </summary>
    public partial class EmployeeHomePage : Window
    {
        public EmployeeHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //search
            this.Hide();
            EmployeeSearch employeeSearch = new EmployeeSearch();
            employeeSearch.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PlaceOrder placeOrder = new PlaceOrder();
            placeOrder.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.employee_name.Text = AdminLogin.currentEmployee;
        }

    }
}
