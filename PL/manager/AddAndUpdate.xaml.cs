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
using PL.client;

namespace PL
{

    public partial class AddAndUpdate : Window
    {
        static public readonly IBL bl = BlApi.Factory.Get;

        //public static DependencyProperty ProductDep =
        //   DependencyProperty.Register(nameof(Product), typeof(Product), typeof(mainClient));
        //Product Product { get => (Product)GetValue(ProductDep); set => SetValue(ProductDep, value); }
        //public static DependencyProperty CategoryDep=
        //    DependencyProperty.Register(nameof(Categorys), typeof(Category), typeof(mainClient));



        public BO.Product Product
        {
            get { return (BO.Product?)GetValue(productCurrnetProperty); }
            set { SetValue(productCurrnetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for productCurrnet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty productCurrnetProperty =
            DependencyProperty.Register(nameof(Product), typeof(BO.Product), typeof(AddAndUpdate));



        public bool AddMode
        {
            get { return (bool)GetValue(AddModeDep); }
            set { SetValue(AddModeDep, value); }
        }

        // Using a DependencyProperty as the backing store for AddMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddModeDep =
            DependencyProperty.Register(nameof(AddMode), typeof(bool), typeof(AddAndUpdate));





        public Array Categorys
        {
            get { return (Array)GetValue(CategorysDep); }
            set { SetValue(CategorysDep, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CategorysDep =
            DependencyProperty.Register(nameof(Categorys), typeof(Array), typeof(AddAndUpdate));

        /// <summary>
        /// constructor for update window
        /// </summary>
        /// <param name="product"></param>
        public AddAndUpdate(int id = 0)
        {
            Categorys = Enum.GetValues(typeof(Category));
            InitializeComponent();
            AddMode = id != 0;
            add.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;
            try
            {
                if (id != 0)
                    Product = bl!.Product.GetProductM(id);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
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
                bl.Product.AddProduct(Product);
            }
            catch (Exception ex)
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
                bl.Product.Update(Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }


    }
}
