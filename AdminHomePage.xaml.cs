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
using System.Data;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        EmployeeContext emp;
        public AdminHomePage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.ShowDialog();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //add new employee in db and show in data view
            this.emp = new EmployeeContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

            Employee employee = new Employee()
            {
                Firstname = this.TextBox3.Text,
                Lastname = TextBox4.Text,
                Email = TextBox8.Text,
                EmployeeId = this.emp.GetNextEmployeeId(),
                Address = TextBox5.Text,
                city = TextBox7.Text,
                Username = TextBox2.Text,
                PhoneNo = Convert.ToInt64(TextBox6.Text),
                Password = PasswordBox1.Password
            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.emp.RegisterEmployeeToDB(employee, out string userMessage, out errorMessage);
            if (transactionStatus == true)
            {
                MessageBox.Show("Congratulations Employee account has been successfully created " +
                    userMessage + " " + errorMessage);
                Reset();
                this.DataGridView1.ItemsSource = this.emp.PopulateDataGrid();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new employee due to \n" + errorMessage);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.emp = new EmployeeContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

            this.DataGridView1.ItemsSource = this.emp.PopulateDataGrid();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //edit
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == ""
                || TextBox7.Text == "" || TextBox8.Text == "")
            {
                MessageBox.Show("Select the Employee Record which you want to edit");
                return;
            }
            
            Employee employee = new Employee()
            {
                Firstname = TextBox3.Text,
                Lastname = TextBox4.Text,
                Email = TextBox8.Text,
                EmployeeId = Convert.ToInt32(TextBox1.Text),
                Address = TextBox5.Text,
                city = TextBox7.Text,
                Username = TextBox2.Text,
                PhoneNo = Convert.ToInt64(TextBox6.Text),
                Password = PasswordBox1.Password
            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.emp.UpdateEmployeeDB(employee, out string userMessage, out errorMessage);
            if (transactionStatus == true)
            {
                MessageBox.Show("Employee data has been successfully updated " +
                    userMessage + " " + errorMessage);
                Reset();
                this.DataGridView1.ItemsSource = this.emp.PopulateDataGrid();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new employee due to \n" + errorMessage);
            }
        }
        private void DataGridView1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView row in this.DataGridView1.SelectedItems)
            {
                System.Data.DataRow MyRow = row.Row;
                int id = Convert.ToInt32(MyRow[0]);
                string username = MyRow[1].ToString();
                string password = MyRow[2].ToString();
                string fname = MyRow[3].ToString();
                string lname = MyRow[4].ToString();
                string address = MyRow[5].ToString();
                long phone = Convert.ToInt64(MyRow[6]);
                string city = MyRow[7].ToString();
                string email = MyRow[8].ToString();

                TextBox3.Text = fname;
                TextBox4.Text = lname;
                TextBox8.Text = email;
                TextBox1.Text = id.ToString();
                TextBox5.Text = address;
                TextBox7.Text = city;
                TextBox2.Text = username;
                TextBox6.Text = phone.ToString();
                PasswordBox1.Password = password;
            }
            this.DataGridView1.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == ""
                || TextBox7.Text == "" || TextBox8.Text == "")
            {
                MessageBox.Show("Select the Employee Record which you want to delete");
                return;
            }

            Employee employee = new Employee()
            {
                Firstname = TextBox3.Text,
                Lastname = TextBox4.Text,
                Email = TextBox8.Text,
                EmployeeId = Convert.ToInt32(TextBox1.Text),
                Address = TextBox5.Text,
                city = TextBox7.Text,
                Username = TextBox2.Text,
                PhoneNo = Convert.ToInt64(TextBox6.Text),
                Password = PasswordBox1.Password
            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.emp.DeleteEmployeeDB(employee, out string userMessage, out errorMessage);
            if (transactionStatus == true)
            {
                MessageBox.Show("Employee data has been successfully deleted. " +
                    userMessage + " " + errorMessage);

                this.DataGridView1.ItemsSource = this.emp.PopulateDataGrid();
                Reset();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new employee due to \n" + errorMessage);
            }
        }

        public void Reset()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox1.Text = "";
            TextBox5.Text = "";
            TextBox7.Text = "";
            TextBox2.Text = "";
            TextBox6.Text = "";
            PasswordBox1.Password = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminPreviledges adminPreviledges = new AdminPreviledges();
            adminPreviledges.ShowDialog();
        }
    }
}
