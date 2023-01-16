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
    /// Interaction logic for OrderMain.xaml
    /// </summary>
    public partial class OrderMain : Window
    {

        static readonly IBL bl = Factory.Get;



        public IEnumerable<OrderForList> OrderList
        {
            get { return (IEnumerable<OrderForList>)GetValue(OrderListDep); }
            set { SetValue(OrderListDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderListDep =
            DependencyProperty.Register("OrderList", typeof(IEnumerable<OrderForList>), typeof(OrderMain));


        public static readonly DependencyProperty ComboOptionProperty =
          DependencyProperty.Register("ComboOption", typeof(Array), typeof(OrderMain));


        public Array ComboOption
        {
            get { return (Array)GetValue(ComboOptionProperty); }
            set { SetValue(ComboOptionProperty, value); }
        }

        public OrderMain()
        {
            InitializeComponent();
            ComboOption = Enum.GetValues(typeof(OrderStatus));
            OrderList = bl.Order.GetOrders();
        }

        private void UpdateOrder(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            OrderForList select = (OrderForList)((ListView)sender).SelectedItem;
            new OrderUpdate(select.Id).ShowDialog();
            try
            {
                OrderList = bl.Order.GetOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var select = (OrderStatus)((ComboBox)sender).SelectedItem;
            OrderList = bl.Order.GetOrders(x => x.Status == select);
        }
    }
}
