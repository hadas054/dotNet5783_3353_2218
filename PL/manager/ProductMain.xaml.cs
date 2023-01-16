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
    /// Interaction logic for ProductMain.xaml
    /// </summary>
    public partial class ProductMain : Window
    {
        static readonly IBL bl = Factory.Get;



        public IEnumerable<ProductForList> ProductList
        {
            get { return (IEnumerable<ProductForList>)GetValue(ProductListDep); }
            set { SetValue(ProductListDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductListDep =
            DependencyProperty.Register("ProductList", typeof(IEnumerable<ProductForList>), typeof(ProductMain));



        public Array ComboOption
        {
            get { return (Array)GetValue(ComboOptionProperty); }
            set { SetValue(ComboOptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ComboOption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboOptionProperty =
            DependencyProperty.Register("ComboOption", typeof(Array), typeof(ProductMain));



        public ProductMain()
        {
            InitializeComponent();
            ProductList = bl.Product.GetProductsList();
            ComboOption = Enum.GetValues(typeof(Category));
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            new AddAndUpdate().ShowDialog();
            try
            {
                ProductList = bl.Product.GetProductsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProduct(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            ProductForList select = (ProductForList)((ListView)sender).SelectedItem;
            new AddAndUpdate(select.Id).ShowDialog();
            try
            {
                ProductList = bl.Product.GetProductsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            var select = (Category)((ComboBox)sender).SelectedItem;
            ProductList = bl.Product.GetProductsList(x => x.Category == select);
        }
    }
}
