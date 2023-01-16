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

namespace PL.manager
{
    /// <summary>
    /// Interaction logic for OrderUpdate.xaml
    /// </summary>
    public partial class OrderUpdate : Window
    {
        IBL bl = Factory.Get;
        public Array ComboOption
        {
            get { return (Array)GetValue(ComboOptionDep); }
            set { SetValue(ComboOptionDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboOptionDep =
            DependencyProperty.Register(nameof(ComboOption), typeof(Array), typeof(OrderUpdate));



        public BO.Order Order
        {
            get { return (BO.Order)GetValue(OrderDep); }
            set { SetValue(OrderDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderDep =
            DependencyProperty.Register(nameof(Order), typeof(BO.Order), typeof(OrderUpdate));



        public OrderUpdate(int id)
        {
            Order = bl.Order.GetOrder(id);
            InitializeComponent();
        }

        private void ShipOrder(object sender, MouseButtonEventArgs e)
        {
            Order tmp = bl.Order.SentOrder(Order.Id);
            Order = new Order();
            Order = tmp;
        }

        private void DeliveryOrder(object sender, MouseButtonEventArgs e)
        {
            Order tmp = bl.Order.DeliveredOrder(Order.Id);
            Order = new Order();
            Order = tmp;
        }
    }
}
