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
        public static readonly IBL bl = Factory.Get;

        Cart cart;

        public static DependencyProperty ProductsListDep =
            DependencyProperty.Register(nameof(ProductsList), typeof(IEnumerable<ProductForList>), typeof(mainClient));
        IEnumerable<ProductForList?> ProductsList { get => (IEnumerable<ProductForList?>)GetValue(ProductsListDep); set => SetValue(ProductsListDep, value); }

        public ICollectionView CollectionViewProductItemList { set; get; }
        private string groupName = "Category";
        private PropertyGroupDescription groupDescription;
        public mainClient()
        {
            InitializeComponent();
            ProductsList = bl.Product.GetProductsList();
            cart = new Cart { Items = new List<OrderItem>() };
            CollectionViewProductItemList = CollectionViewSource.GetDefaultView(ProductsList);
            groupDescription = new PropertyGroupDescription(groupName);
            CollectionViewProductItemList.GroupDescriptions.Add(groupDescription);
        }

        private void AddToCart(object sender, MouseButtonEventArgs e)
        {
            var selectProduct = (ProductForList)((Button)sender).Tag;
            try
            {
                Cart temp = bl.cart.AddProduct(cart, selectProduct.Id);
                cart = null;
                cart = temp;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CartButton(object sender, RoutedEventArgs e)
        {
            new CartWindow(cart).Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
