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

namespace PL.client
{
    /// <summary>
    /// Interaction logic for mainClient.xaml
    /// </summary>
    public partial class mainClient : Window
    {
        IBL bl;
        Cart cart;
        IEnumerable<ProductForList?> products;
        public mainClient()
        {
            InitializeComponent();
            bl = Factory.Get;
            products = bl.Product.GetProducts();
            cart = new Cart { Items = new List<OrderItem>() };
            this.DataContext = this;
        }

        private void Dresses(object sender, MouseButtonEventArgs e)
        {
            DressesGrid.Visibility = Visibility;
            MainGrid.Visibility = Visibility.Hidden;
            dresessLv.ItemsSource = products.Where(x => x!.Category == Category.Dresses);
        }

        private void pants(object sender, MouseButtonEventArgs e)
        {

        }

        private void jackets(object sender, MouseButtonEventArgs e)
        {

        }

        private void Shirts(object sender, MouseButtonEventArgs e)
        {

        }

        private void DresessBack(object sender, RoutedEventArgs e)
        {
            DressesGrid.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;
        }

        private void OpenCart(object sender, RoutedEventArgs e)
        {
            MyCart.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Hidden;
            cartList.ItemsSource = cart.Items;
        }

        private void CartBack(object sender, RoutedEventArgs e)
        {
            MyCart.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;

        }

        private void addDresess(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dresessLv.SelectedItem is ProductForList p)
                    bl.cart.AddProduct(cart, p.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
