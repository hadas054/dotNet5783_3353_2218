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
        public IEnumerable<OrderForList> OrderLIst
        {
            get { return (IEnumerable<OrderForList>)GetValue(OrderLIstDep); }
            set { SetValue(OrderLIstDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderLIstDep =
            DependencyProperty.Register(nameof(OrderLIst), typeof(IEnumerable<OrderForList>), typeof(OrderMain));


        public Array ComboOption
        {
            get { return (Array)GetValue(ComboOptionDep); }
            set { SetValue(ComboOptionDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboOptionDep =
            DependencyProperty.Register(nameof(ComboOption), typeof(Array), typeof(OrderMain));


        
        public OrderMain()
        {
            InitializeComponent();
            OrderLIst = bl.Order.GetOrders();
            ComboOption = Enum.GetValues(typeof(OrderStatus));
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            var sele
            OrderLIst = bl.Order.GetOrders(x=> x?.Category == )
        }
    }
}
