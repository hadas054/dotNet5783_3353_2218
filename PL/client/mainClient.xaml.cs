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

        public static DependencyProperty ProductsListDep =
            DependencyProperty.Register(nameof(ProductsList), typeof(IEnumerable<ProductForList>), typeof(mainClient));
        IEnumerable<ProductForList?> ProductsList { get => (IEnumerable<ProductForList?>)GetValue(ProductsListDep); set => SetValue(ProductsListDep, value); }



        public Cart Cart
        {
            get { return (Cart)GetValue(CartDep); }
            set { SetValue(CartDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartDep =
            DependencyProperty.Register(nameof(Cart), typeof(Cart), typeof(mainClient));



        public ICollectionView CollectionViewProductItemList { set; get; }
        private string groupName = "Category";
        private PropertyGroupDescription groupDescription;
        public mainClient()
        {
            Cart = new Cart { Items = new List<OrderItem>() };
            InitializeComponent();
            ProductsList = bl.Product.GetProductsList();
            CollectionViewProductItemList = CollectionViewSource.GetDefaultView(ProductsList);
            groupDescription = new PropertyGroupDescription(groupName);
            CollectionViewProductItemList.GroupDescriptions.Add(groupDescription);
        }

        private void AddToCart(object sender, MouseButtonEventArgs e)
        {
            var selectProduct = (ProductForList)((Button)sender).Tag;
            try
            {
                Cart temp = bl.cart.AddProduct(Cart, selectProduct.Id);
                Cart = null;
                Cart = temp;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CartButton(object sender, RoutedEventArgs e)
        {
            new CartWindow(Cart).Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
