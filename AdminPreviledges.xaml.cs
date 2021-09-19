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

namespace PizzaOrderingSystem
{
    /// <summary>
    /// Interaction logic for AdminPreviledges.xaml
    /// </summary>
    public partial class AdminPreviledges : Window
    {
        public AdminPreviledges()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminHomePage adminHomePage = new AdminHomePage();
            adminHomePage.ShowDialog();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add pizza
            this.Hide();
            ManagePizza managePizza = new ManagePizza();
            managePizza.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin admin = new AdminLogin();
            admin.ShowDialog();
        }
    }
}
