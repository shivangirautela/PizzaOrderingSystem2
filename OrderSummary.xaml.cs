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
using System.Configuration;
using PizzaOrderBLL;
using PizzaOrderCLasses;
using System.Windows.Forms;
using System.Data;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummary : Window
    {
        DateTime currentOrderTime;

        public OrderSummary()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PlaceOrder place = new PlaceOrder();
            place.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add order to database
            CustomerOrder customerOrder = OrderContext.GetCustomerOrder();
            if (OrderContext.AddOrderToDB(customerOrder, out string userMesssage, out string userException))
            {
                this.Hide();
                PaymentInfo paymentInfo = new PaymentInfo();
                paymentInfo.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Failed to place Order due to exception " + userException);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = OrderContext.ShowData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (CustomerOrder row in this.datagrid.Items)
            {
                currentOrderTime = row.Delivery;
            }
            DateTime orderdateTime = currentOrderTime;
            OrderContext.OrderStatus(orderdateTime, DateTime.Now);
            this.datagrid.ItemsSource = OrderContext.ShowData();
        }

        private void datagrid_SelectedCellsChanged(object sender, System.EventArgs e)
        {
           
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
