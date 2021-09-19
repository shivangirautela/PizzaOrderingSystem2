using System;
using System.Collections.Generic;
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
using PizzaOrderingSystem;
using System.Configuration;

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for PizzaHomePage.xaml
    /// </summary>
    public partial class PizzaHomePage : Window
    {
        PizzaOrderContext pizzaOrder;
        
        public PizzaHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerHomePage customerHomePage = new CustomerHomePage();
            customerHomePage.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string pizzaName = "";
            int pizzaPrice = 0, totalOrderPrice = 0;
            if (this.radiobtn1.IsChecked == true)
            {
                pizzaName = radiobtn1.Content.ToString();
            }
            else if (this.radiobtn2.IsChecked == true)
            {
                pizzaName = radiobtn2.Content.ToString();
            }
            else if (this.radiobtn3.IsChecked == true)
            {
                pizzaName = radiobtn3.Content.ToString();
            }
            else if (this.radiobtn4.IsChecked == true)
            {
                pizzaName = radiobtn4.Content.ToString();
            }
            else if (this.radiobtn5.IsChecked == true)
            {
                pizzaName = radiobtn5.Content.ToString();
            }
            else if (this.radiobtn6.IsChecked == true)
            {
                pizzaName = radiobtn6.Content.ToString();
            }
            else if (this.radiobtn7.IsChecked == true)
            {
                pizzaName = radiobtn7.Content.ToString();
            }
            else if (this.radiobtn8.IsChecked == true)
            {
                pizzaName = radiobtn8.Content.ToString();
            }
            else if (this.radiobtn9.IsChecked == true)
            {
                pizzaName = radiobtn9.Content.ToString();
            }
            else if (this.radiobtn10.IsChecked == true)
            {
                pizzaName = radiobtn10.Content.ToString();
            }
            else if (this.radiobtn11.IsChecked == true)
            {
                pizzaName = radiobtn11.Content.ToString();
            }
            else if (this.radiobtn12.IsChecked == true)
            {
                pizzaName = radiobtn12.Content.ToString();
            }
            else if (this.radiobtn13.IsChecked == true)
            {
                pizzaName = radiobtn13.Content.ToString();
            }
            else if (this.radiobtn14.IsChecked == true)
            {
                pizzaName = radiobtn14.Content.ToString();
            }
            else if (this.radiobtn15.IsChecked == true)
            {
                pizzaName = radiobtn15.Content.ToString();
            }
            else if (this.radiobtn16.IsChecked == true)
            {
                pizzaName = radiobtn16.Content.ToString();
            }
            else if (this.radiobtn17.IsChecked == true)
            {
                pizzaName = radiobtn17.Content.ToString();
            }
            else if (this.radiobtn18.IsChecked == true)
            {
                pizzaName = radiobtn18.Content.ToString();
            }
            else if (this.radiobtn19.IsChecked == true)
            {
                pizzaName = radiobtn19.Content.ToString();
            }
            Regex re = new Regex(@"\d+");
            Match m = re.Match(pizzaName);
            if (m.Success)
            {
                pizzaPrice += Convert.ToInt32(m.Value);
            }
            totalOrderPrice += pizzaPrice;
            string category = "";
            if (this.catgrybtn1.IsChecked == true)
            {
                category = this.catgrybtn1.Content.ToString();
            }
            else if (this.catgrybtn2.IsChecked == true)
            {
                category = this.catgrybtn2.Content.ToString();
            }
            else if (this.catgrybtn3.IsChecked == true)
            {
                category = this.catgrybtn3.Content.ToString();
            }
            else if (this.catgrybtn4.IsChecked == true)
            {
                category = this.catgrybtn4.Content.ToString();
            }
            m = re.Match(category);
            if (m.Success)
            {
                totalOrderPrice += Convert.ToInt32(m.Value);
            }
            string baseName = "";
            if (this.rdbtn1.IsChecked == true)
            {
                baseName = this.rdbtn1.Content.ToString();
            }
            else if (this.rdbtn2.IsChecked == true)
            {
                baseName = this.rdbtn2.Content.ToString();
            }
            else if (this.rdbtn3.IsChecked == true)
            {
                baseName = this.rdbtn3.Content.ToString();
            }
            else if (this.rdbtn4.IsChecked == true)
            {
                baseName = this.rdbtn4.Content.ToString();
            }
            m = re.Match(baseName);
            if (m.Success)
            {
                totalOrderPrice += Convert.ToInt32(m.Value);
            }
            string topping = "";
            if (this.checkbox1.IsChecked == true)
            {
                topping = this.checkbox1.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.checkbox2.IsChecked == true)
            {
                topping = this.checkbox2.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.checkbox3.IsChecked == true)
            {
                topping = this.checkbox3.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.checkbox4.IsChecked == true)
            {
                topping = this.checkbox4.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.checkbox5.IsChecked == true)
            {
                topping = this.checkbox5.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.checkbox6.IsChecked == true)
            {
                topping = this.checkbox6.Content.ToString();
                m = re.Match(topping);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            string sides = "";

            if (this.chkbox0.IsChecked == true)
            {
                sides = this.chkbox0.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox1.IsChecked == true)
            {
                sides = this.chkbox1.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox2.IsChecked == true)
            {
                sides = this.chkbox2.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox3.IsChecked == true)
            {
                sides = this.chkbox3.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox4.IsChecked == true)
            {
                sides = this.chkbox4.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox5.IsChecked == true)
            {
                sides = this.chkbox5.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox6.IsChecked == true)
            {
                sides = this.chkbox6.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox7.IsChecked == true)
            {
                sides = this.chkbox7.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox8.IsChecked == true)
            {
                sides = this.chkbox8.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox9.IsChecked == true)
            {
                sides = this.chkbox9.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            if (this.chkbox10.IsChecked == true)
            {
                sides = this.chkbox10.Content.ToString();
                m = re.Match(sides);
                totalOrderPrice += ((m.Success) ? Convert.ToInt32(m.Value) : 0);
            }
            this.pizzaOrder = new PizzaOrderContext(ConfigurationManager.ConnectionStrings["connectionDBObj"].ConnectionString);

            Pizza pObj = new Pizza()
            {
                PizzaId = this.pizzaOrder.GetNextPizzaId(),
                PizzaName = pizzaName,
                Price = pizzaPrice,
                pizzacategory = category
            };

            if (this.pizzaOrder.Addpizza(pObj, out string errorMessage))
            {
                OrderContext.AcceptTotalPrice(totalOrderPrice);
                this.Hide();
                PlaceOrder place = new PlaceOrder();
                place.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pizza could not be added.");
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PlaceOrder placeOrder = new PlaceOrder();
            placeOrder.ShowDialog();
        }
    }
}
