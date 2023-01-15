using BlApi;
using BO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static DependencyProperty ProductListDep =
            DependencyProperty.Register(nameof(Products), typeof(IEnumerable<ProductForList>), typeof(mainClient));
        IEnumerable<ProductForList?> Products { get => (IEnumerable<ProductForList?>)GetValue(ProductListDep); set => SetValue(ProductListDep, value); }

        public ICollectionView CollectionViewProductItemList { set; get; }
        private string groupName = "Category";
        private PropertyGroupDescription groupDescription;
        public mainClient()
        {
            InitializeComponent();
            bl = Factory.Get;
            Products = bl.Product.GetProducts();
            cart = new Cart { Items = new List<OrderItem>() };
            CollectionViewProductItemList = CollectionViewSource.GetDefaultView(ProductsList);
            groupDescription = new PropertyGroupDescription(groupName);
            CollectionViewProductItemList.GroupDescriptions.Add(groupDescription);
        }

        private void Dresses(object sender, MouseButtonEventArgs e)
        {
            DressesGrid.Visibility = Visibility;
            MainGrid.Visibility = Visibility.Hidden;
            Products = Products.Where(x => x!.Category == Category.Dresses);
        }

        private void pants(object sender, MouseButtonEventArgs e)
        {
            pantsGrid.Visibility = Visibility;
            MainGrid.Visibility = Visibility.Hidden;
            PantsLv.ItemsSource = Products.Where(x => x!.Category == Category.pants);
        }

        private void jackets(object sender, MouseButtonEventArgs e)
        {
            JacketsGrid.Visibility = Visibility;
            MainGrid.Visibility = Visibility.Hidden;
            JacketsLv.ItemsSource = Products.Where(x => x!.Category == Category.jackets);
        }

        private void Shirts(object sender, MouseButtonEventArgs e)
        {
            ShirtsGrid.Visibility = Visibility;
            MainGrid.Visibility = Visibility.Hidden;
            ShirtsLv.ItemsSource = Products.Where(x => x!.Category == Category.Shirts);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PantsBack(object sender, RoutedEventArgs e)
        {
            pantsGrid.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;
        }

        private void addPants(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (PantsLv.SelectedItem is ProductForList p)
                    bl.cart.AddProduct(cart, p.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void JacketsBack(object sender, RoutedEventArgs e)
        {
            JacketsGrid.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;
        }

        private void addJackets(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (JacketsLv.SelectedItem is ProductForList p)
                    bl.cart.AddProduct(cart, p.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ShirtsBack(object sender, RoutedEventArgs e)
        {
            ShirtsGrid.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;
        }

        private void addShirts(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ShirtsLv.SelectedItem is ProductForList p)
                    bl.cart.AddProduct(cart, p.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
