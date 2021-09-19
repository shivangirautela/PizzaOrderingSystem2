using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using PizzaOrderBLL;
using PizzaOrderCLasses;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        CustomerLogin signUp;
        public SignUp()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
            contact_details.Text = "";
            textbox_city.Text = "";
            existing_email.Text = "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public bool VerifyDetails(String email, String address, String password)
        {
            if (email.Length == 0)
            {
                errormessage.Text = "Enter an Email";
                textBoxEmail.Focus();
                return false;
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a Valid email";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
                return false;
            }
            else if (passwordBox1.Password.Length == 0)
            {
                errormessage.Text = "Enter Password";
                passwordBox1.Focus();
                return false;
            }
            else if (passwordBoxConfirm.Password.Length == 0)
            {
                errormessage.Text = "Please confirm password";
                passwordBoxConfirm.Focus();
                return false;
            }
            else if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                errormessage.Text = "Password and the Confirm Password must be same";
                passwordBoxConfirm.Focus();
                return false;
            }
            else if (contact_details.Text.Length != 10)
            {
                errormessage.Text = "Enter 10 digit mobile number";
                contact_details.Focus();
                return false;
            }
            return true;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (VerifyDetails(this.textBoxEmail.Text, this.textBoxAddress.Text, this.passwordBox1.Password))
            {
                this.signUp = new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

                Customer cust = new Customer()
                {
                    FistName = this.textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    CustomerEmail = textBoxEmail.Text,
                    CustomerAddress = textBoxAddress.Text,
                    CustomerCity = textbox_city.Text,
                    CustomerId = this.signUp.GetCustomerID(),
                    PhoneNumber = Convert.ToInt32(contact_details.Text)
                };
                MessageBox.Show(textBoxAddress.Text);
                RegisteredCustomer register = new RegisteredCustomer()
                {
                    FirstName = textBoxFirstName.Text,
                    UserEmail = textBoxEmail.Text,
                    Password = passwordBox1.Password
                };
                Boolean transactionStatus = false;
                String errorMessage = string.Empty;

                if (this.signUp.IsDuplicateCustomer(textBoxEmail.Text))
                {
                    MessageBox.Show("User Email already registered.");
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    transactionStatus = this.signUp.RegisterCustomerToDB(cust, register, out string userMessage, out errorMessage);
                    if (transactionStatus == true)
                    {
                        MessageBox.Show("Congratulations  " + cust.FistName + " You're account has been succefully created " +
                            userMessage + " " + errorMessage);
                        this.Hide();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Sorry Could not process request due to \n" + errorMessage);
                    }
                }
            }
            else
                MessageBox.Show("Enter valid credentials only.");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.signUp = new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //update code
            this.signUp = new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
            Customer cust = new Customer()
            {
                FistName = this.textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                CustomerEmail = textBoxEmail.Text,
                CustomerAddress = textBoxAddress.Text,
                CustomerCity = textbox_city.Text,
                PhoneNumber = Convert.ToInt32(contact_details.Text)
            };
            RegisteredCustomer register = new RegisteredCustomer()
            {
                FirstName = textBoxFirstName.Text,
                UserEmail = textBoxEmail.Text,
                Password = passwordBox1.Password
            };
            string errormessage = "";
            string previousEmail = this.existing_email.Text;
            if (this.signUp.UpdateCustomerDetails(previousEmail, cust, register, out string userMessage, out errormessage))
            {
                MessageBox.Show("Customer Details Updated Succesfully");
                Reset();
            }
            else
                MessageBox.Show(userMessage + "Customer Details not updated due to : " + errormessage);
        }
    }
}
