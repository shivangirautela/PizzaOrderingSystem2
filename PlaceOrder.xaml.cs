using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for PlaceOrder.xaml
    /// </summary>
    public partial class PlaceOrder : Window
    {
        CustomerLogin customer;
        PizzaOrderContext orderContext;
        public static Customer custObj;
        Pizza pizza;
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.customer = new CustomerLogin(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
            this.orderContext = new PizzaOrderContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
            this.datagrid1.ItemsSource = this.customer.PopulateDataGridAllCustomers();
            this.pizza_datagrid.ItemsSource = this.orderContext.PopulateDataGridAllPizzas();
        }

        private void datagrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView row in this.datagrid1.SelectedItems)
            {
                System.Data.DataRow MyRow = row.Row;
                int id = Convert.ToInt32(MyRow[0]);
                string fname = MyRow[1].ToString();
                string lname = MyRow[2].ToString();
                string address = MyRow[3].ToString();
                long phone = Convert.ToInt64(MyRow[4]);
                string city = MyRow[5].ToString();
                string email = MyRow[6].ToString();
                custObj = new Customer()
                {
                    CustomerId = id,
                    FistName = fname,
                    LastName = lname,
                    CustomerAddress = address,
                    PhoneNumber = phone,
                    CustomerCity = city,
                    CustomerEmail = email
                };
            }
            OrderContext.AcceptCustomerId(custObj.CustomerId);
            this.datagrid1.Focus();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EmployeeHomePage employeeHomePage = new EmployeeHomePage();
            employeeHomePage.ShowDialog();
        }

        private void pizza_datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView row in this.pizza_datagrid.SelectedItems)
            {
                System.Data.DataRow MyRow = row.Row;
                int id = Convert.ToInt32(MyRow[0]);
                string pname = MyRow[1].ToString();
                string imagurl = MyRow[2].ToString();
                string category = MyRow[3].ToString();
                int price = Convert.ToInt32(MyRow[4]);
                pizza = new Pizza()
                {
                    PizzaId = id,
                    pizzacategory = category,
                    imageurl = imagurl,
                    PizzaName = pname,
                    Price = price
                };
            }
            OrderContext.AcceptPizzaId(pizza.PizzaId);
            this.datagrid1.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderContext.AcceptOrderDateTime(DateTime.Now);
            OrderContext.GetNextOrderId();
            this.Hide();
            OrderSummary orderSummary = new OrderSummary();
            orderSummary.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PizzaHomePage pizzaHomePage = new PizzaHomePage();
            pizzaHomePage.ShowDialog();
        }
    }
}
