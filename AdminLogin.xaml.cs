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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        AdminContext adminContext;
        EmployeeContext employeeContext;
        public static String currentEmployee;
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.Select_Your_Role.SelectionBoxItem.ToString() == "Employee Login")
            {
                Employee employee = new Employee()
                {
                    Username = this.user_name.Text,
                    Password = this.password.Password
                };
                Boolean transactionStatus = false;
                String errorMessage = string.Empty;
                this.employeeContext = new EmployeeContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
                transactionStatus = this.employeeContext.VerifyEmployeeLogin(employee, out string userMessage, out errorMessage);
                if (transactionStatus == true)
                {
                    MessageBox.Show("Welcome to Pizzeria !" + userMessage + " " + employee.Firstname);
                    AdminLogin.currentEmployee = employee.Username;
                    OrderContext.AcceptEmployeeId(this.employeeContext.GetEmployeeIdByUserName(employee.Username));
                    this.Hide();
                    EmployeeHomePage employeeHomePage = new EmployeeHomePage();
                    employeeHomePage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry Could not process request due to \n" + userMessage + errorMessage);
                }
            }
            else
            {
                AdminCredentials adminCredentials = new AdminCredentials()
                {
                    UserName = this.user_name.Text,
                    Password = this.password.Password
                };
                Boolean transactionStatus = false;
                String errorMessage = string.Empty;
                this.adminContext = new AdminContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
                transactionStatus = this.adminContext.VerifyAdminLogin(adminCredentials, out string userMessage, out errorMessage);
                if (transactionStatus == true)
                {
                    MessageBox.Show("Welcome to Pizzeria !" + userMessage + " " + adminCredentials.UserName);
                    this.Hide();
                    AdminPreviledges admin = new AdminPreviledges();
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry Could not process request due to \n" + userMessage + errorMessage);
                }
            }
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.ShowDialog();
        }
        
    }
}
