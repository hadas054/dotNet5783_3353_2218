using BlApi;
using BO;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderTracking.xaml
    /// </summary>
    public partial class OrderTrackingWindow : Window
    {
        IBL bl = Factory.Get;

        public OrderTracking OrderTracking
        {
            get { return (OrderTracking)GetValue(OrderTrackingDep); }
            set { SetValue(OrderTrackingDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderTrackingDep =
            DependencyProperty.Register("OrderTracking", typeof(OrderTracking), typeof(OrderTrackingWindow));


        public OrderTrackingWindow()
        {
            InitializeComponent();
            OrderTracking = new OrderTracking { Tracking = new List<Tuple<DateTime?, OrderStatus>>() };
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderTracking = bl.Order.OrderTracking(OrderTracking.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
