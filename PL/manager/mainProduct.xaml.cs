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
using PL;


namespace PL.manager
{
    /// <summary>
    /// Interaction logic for mainProduct.xaml
    /// </summary>
    public partial class mainProduct : Window
    {
        IBL bl;
        BO.Category[] categoryList;
        public mainProduct()
        {
            InitializeComponent();
            bl = new BL();
            List.ItemsSource = bl.Product.GetProducts();
            categoryList = (Category[])Enum.GetValues(typeof(Category));
            selection.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            new AddAndUpdate().Show();
        }

        private void UpdateProduct(object sender, MouseButtonEventArgs e)
        {
            new AddAndUpdate().Show();
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {

            if (selection.SelectedItem is Category category)
                List.ItemsSource = bl.Product.GetProducts().Where(x => x.Category == category);
                //foreach (var item in categoryList.Where(x => x != category))
                //    selection.Items.Add(item);
        }
    }
}
