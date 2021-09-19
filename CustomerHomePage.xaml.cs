using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for CustomerHomePage.xaml
    /// </summary>
    public partial class CustomerHomePage : Window
    {
        public CustomerHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(this.add_update.IsChecked== true)
            {
                this.add_updateCust.IsEnabled = true;
                this.search_ing.IsEnabled = false;
                this.vieworder.IsEnabled = false;
                this.checkout.IsEnabled = false;
                this.place_neworder.IsEnabled = false;
            }
        }

        private void view_order_Checked(object sender, RoutedEventArgs e)
        {
            if(view_order.IsChecked==true)
            {
                vieworder.IsEnabled = true;
                this.search_ing.IsEnabled = false;
                this.add_updateCust.IsEnabled = false;
                this.checkout.IsEnabled = false;
                this.place_neworder.IsEnabled = false;
            }
        }

        private void search_Checked(object sender, RoutedEventArgs e)
        {
            if(search.IsChecked==true)
            {
                search_ing.IsEnabled = true;
                this.add_updateCust.IsEnabled = false;
                this.vieworder.IsEnabled = false;
                this.checkout.IsEnabled = false;
                this.place_neworder.IsEnabled = false;
            }
        }

        private void place_order_Checked(object sender, RoutedEventArgs e)
        {
            if(place_order.IsChecked==true)
            {
                checkout.IsEnabled = true;
                this.add_custumer.IsEnabled = false;
                this.vieworder.IsEnabled = false;
                this.search_ing.IsEnabled = false;
                this.place_neworder.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //search ingredients
            SearchIngredients search = new SearchIngredients();
            this.Hide();
            search.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //checkout
            this.Hide();
            PaymentInfo paymentInfo = new PaymentInfo();
            paymentInfo.Show();
        }

        private void add_custumer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //order summary
            this.Hide();
            OrderSummary orderSummary = new OrderSummary();
            orderSummary.ShowDialog();
        }

        private void place_neworder_Click(object sender, RoutedEventArgs e)
        {
            //navigate to pizza home page
            //OrderContext.AcceptCustomerId()
            this.Hide();
            PizzaHomePage pizzaHomePage = new PizzaHomePage();
            pizzaHomePage.ShowDialog();
        }

        private void add_updateCust_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp sign = new SignUp();
            sign.ShowDialog();
        }
    }
}
