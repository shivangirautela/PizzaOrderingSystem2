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
using PizzaOrderingSystem;
using PizzaOrderBLL;
using PizzaOrderCLasses;
using System.Configuration;
using System.Data;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for ManagePizza.xaml
    /// </summary>
    public partial class ManagePizza : Window
    {
        PizzaOrderContext pizza;
        public ManagePizza()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.pizza = new PizzaOrderContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

            Pizza p = new Pizza()
            {
                PizzaName = this.TextBox2.Text,
                pizzacategory = this.TextBox4.Text,
                Price = Convert.ToInt32(this.TextBox3.Text)

            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.pizza.Addpizza(p, out string userMessage);
            if (transactionStatus == true)
            {
                MessageBox.Show("pizza has been successfully added " +
                    userMessage + " " + errorMessage);
                Reset();
                this.DataGridView2.ItemsSource = this.pizza.PopulateDataGridAllPizzas();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new pizza due to \n" + errorMessage);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.pizza = new PizzaOrderContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

            this.DataGridView2.ItemsSource = this.pizza.PopulateDataGridAllPizzas();
        }
        public void Reset()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        private void DataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in this.DataGridView2.SelectedItems)
            {
                System.Data.DataRow MyRow = row.Row;
                int pizzaid = Convert.ToInt32(MyRow[0]);
                string pizzaName = MyRow[1].ToString();
                string Category = MyRow[2].ToString();
                int price = Convert.ToInt32(MyRow[3]);
                TextBox2.Text = pizzaName;
                TextBox3.Text = price.ToString();
                TextBox4.Text = Category;
                TextBox1.Text = pizzaid.ToString();

            }
            this.DataGridView2.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
            {
                MessageBox.Show("Select the Pizza Record which you want to edit");
                return;
            }

            Pizza p = new Pizza()
            {
                PizzaName = this.TextBox2.Text,
                pizzacategory = this.TextBox4.Text,
                Price = Convert.ToInt32(this.TextBox3.Text)

            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.pizza.EditPizza(p, out string userMessage, out string userexception);
            if (transactionStatus == true)
            {
                MessageBox.Show("Pizza details has been successfully updated " +
                    userMessage + " " + errorMessage);
                Reset();
                this.DataGridView2.ItemsSource = this.pizza.PopulateDataGridAllPizzas();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new pizza due to \n" + errorMessage);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
            {
                MessageBox.Show("Select the Pizza Record which you want to delete");
                return;
            }

            Pizza p = new Pizza()
            {
                PizzaName = this.TextBox2.Text,
                pizzacategory = this.TextBox4.Text,
                Price = Convert.ToInt32(this.TextBox3.Text)

            };
            Boolean transactionStatus = false;
            String errorMessage = string.Empty;
            transactionStatus = this.pizza.DeletePizza(p, out string userMessage, out string userexception);
            if (transactionStatus == true)
            {
                MessageBox.Show("Employee data has been successfully deleted. " +
                    userMessage + " " + errorMessage);

                this.DataGridView2.ItemsSource = this.pizza.PopulateDataGridAllPizzas();
                Reset();
            }
            else
            {
                MessageBox.Show("Sorry Could not add new employee due to \n" + errorMessage);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminPreviledges adminPreviledges = new AdminPreviledges();
            adminPreviledges.ShowDialog();
        }
    }
}
