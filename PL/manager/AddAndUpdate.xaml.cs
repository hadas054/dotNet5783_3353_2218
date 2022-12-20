using BlApi;
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
using BLImplementation;
using BO;

namespace PL
{
    
    public partial class AddAndUpdate : Window
    {
        IBL bl;
        /// <summary>
        /// constructor for Add window
        /// </summary>
        public AddAndUpdate()
        {
            InitializeComponent();
            bl = new BL();
            category.ItemsSource = Enum.GetValues(typeof(Category));
            add.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// constructor for update window
        /// </summary>
        /// <param name="product"></param>
        public AddAndUpdate(ProductForList product)
        {
            InitializeComponent();
            bl = new BL();
            category.ItemsSource = Enum.GetValues(typeof(Category));    

            add.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;

            ID.Text = product.Id.ToString();
            Name.Text = product.Name;
            Amount.Text = bl.Product.GetProductM(product.Id).Instock.ToString();
            Price.Text = product.Price.ToString();
            category.Text = product.Category.ToString();
            ID.IsReadOnly = true;   
        }

        /// <summary>
        /// Add new product to the catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Product.AddProduct(new Product
                {
                    Id = int.Parse(ID.Text),
                    Name = Name.Text,
                    Category = (Category)category.SelectedIndex,
                    Instock = int.Parse(Amount.Text),
                    Price = int.Parse(Price.Text),
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            this.Close();
        }


        /// <summary>
        /// update product from the catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Product.Update(new Product
                {
                    Id = int.Parse(ID.Text),
                    Name = Name.Text,
                    Category = (Category)category.SelectedIndex,
                    Instock = int.Parse(ID.Text),
                    Price = int.Parse(Price.Text),
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
