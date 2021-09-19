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
    /// Interaction logic for PaymentInfo.xaml
    /// </summary>
    public partial class PaymentInfo : Window
    {
        public PaymentInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OrderSummary orderSummary = new OrderSummary();
            orderSummary.ShowDialog();
        }
        private void ProceedButton(object sender, RoutedEventArgs e)
        {
            PaymentMethods Content = new PaymentMethods();
            Content.Show();
            this.Hide();
        }
    }
}
