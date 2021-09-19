using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Configuration;
using PizzaOrderBLL;
using PizzaOrderCLasses;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerLogin login;

        public MainWindow()
        {
            InitializeComponent();
        }
        public bool VerifyCredantials(String userName,String password)
        {
            String userMessage = "";
            if (userName.Length == 0)
            {
                userMessage = "Enter an email.";
                MessageBox.Show(userMessage);

            }
            else if (!Regex.IsMatch(userName, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                userMessage = "Enter a valid email.";
                username.Select(0, username.Text.Length);
                username.Focus();
                MessageBox.Show(userMessage);

            }
            else
            {
                return true;
            }
            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyCredantials(this.username.Text, this.txt_password.Password))
            {
                RegisteredCustomer registeredCustomer =
                    new RegisteredCustomer()
                    {
                        UserEmail = this.username.Text,
                        Password = this.txt_password.Password,
                        FirstName=this.first_name.Text
                    };
                Boolean transactionStatus = false;
                String errorMessage = string.Empty;
                this.login = new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
                transactionStatus = this.login.VerifyCustomer(registeredCustomer,out string userMessage, out errorMessage);
                if (transactionStatus == true)
                {
                    MessageBox.Show("Welcome to Pizzeria New Order , cancel , " + userMessage +" "+ errorMessage);
                    this.Hide();
                    CustomerHomePage customerHome = new CustomerHomePage();
                    customerHome.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry Could not process request due to \n" + userMessage + errorMessage);
                }
            }
            else
                MessageBox.Show("Enter valid credentials ");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.login =
                new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
        }
    }
}
