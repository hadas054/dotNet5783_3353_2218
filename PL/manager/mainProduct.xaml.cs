using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        BO.Category[] categories;
        public ObservableCollection<Category> ComboOption { get; private set; }
        /// <summary>
        /// constructor for the mainproduct
        /// </summary>
        public mainProduct()
        {
            InitializeComponent();
            bl = BlApi.Factory.Get;
            List.ItemsSource = bl.Product.GetProducts();
            categories = (Category[])Enum.GetValues(typeof(Category));
            ComboOption = new ObservableCollection<Category>(categories);
            this.DataContext = this;
        }


        /// <summary>
        /// when you click on the "add new product" the AddAndUpdate window will open 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            new AddAndUpdate().ShowDialog();

            //We will update the list of products after the action we have taken
            try
            {
                List.ItemsSource = bl.Product.GetProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// update product from the catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProduct(object sender, MouseButtonEventArgs e)
        {
            if (List.SelectedItem is ProductForList productForList)
                new AddAndUpdate(productForList).ShowDialog();
            //We will update the list of products after the action we have taken
            try
            {
                List.ItemsSource = bl.Product.GetProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {

            if (selection.SelectedItem is Category category)
            {
                if (category == Category.All)
                    List.ItemsSource = bl.Product.GetProducts();
                else
                    List.ItemsSource = bl.Product.GetProducts(x => x.Category == category);

                ComboOption.Clear();

                foreach (var c in categories.Where(cat => cat != category))
                {
                    ComboOption.Add(c);
                }
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
