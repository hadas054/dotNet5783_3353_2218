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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlApi;
using BLImplementation;
using PL.manager;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
                bl = new BL();
        }

        /// <summary>
        /// when you click on the "manager" in the main window the main product window will open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainProduct(object sender, RoutedEventArgs e)
        {
            new mainProduct().Show();
        }
    }
}
