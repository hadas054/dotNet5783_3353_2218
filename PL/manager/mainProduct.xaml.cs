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
using BlApi;
using BLImplementation;
using BO;

namespace PL.manager
{
    /// <summary>
    /// Interaction logic for mainProduct.xaml
    /// </summary>
    public partial class mainProduct : Window
    {
        IBL bl;   
        public mainProduct()
        {
            InitializeComponent();
            bl = new BL();

            selection.ItemsSource = Enum.GetValues(typeof(Category));
            List.ItemsSource = bl.Product.GetProducts();
        }



        private void AddProduct(object sender, RoutedEventArgs e)
        {
           // new ProductAction().Show();
        }

        private void UpdateProduct(object sender, MouseButtonEventArgs e)
        {
          //  new ProductAction().Show();
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            if (selection.SelectedItem is Category category)
                List.ItemsSource = bl.Product.GetProducts().Where(x => x.Category == category);
        }
    }
}
