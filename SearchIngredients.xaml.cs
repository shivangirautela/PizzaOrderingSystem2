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
    /// Interaction logic for SearchIngredients.xaml
    /// </summary>
    public partial class SearchIngredients : Window
    {
        PizzaOrderContext pizzaOrder;
        public SearchIngredients()
        {
            InitializeComponent();
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(this.combobox1.SelectedItem != null)
            {
                if(this.combobox1.SelectedIndex ==0)
                {
                    this.datagrid.Items.Refresh();
                    this.datagrid.ItemsSource = this.pizzaOrder.DisplayPizzaSearch(this.search_name.Text, "Category");
            
                }
                else if(this.combobox1.SelectedIndex == 1)
                {
                    this.datagrid.Items.Refresh();
                    this.datagrid.ItemsSource = this.pizzaOrder.DisplayPizzaSearch(this.search_name.Text, "Name");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.pizzaOrder = new PizzaOrderContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerHomePage customerHomePage = new CustomerHomePage();
            customerHomePage.ShowDialog();
        }

        private void combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
