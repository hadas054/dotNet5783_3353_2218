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
using PL.client;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;



        public bool _simulatorClick
        {
            get { return (bool)GetValue(_simulatorClickProperty); }
            set { SetValue(_simulatorClickProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _simulatorClick.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _simulatorClickProperty =
            DependencyProperty.Register("_simulatorClick", typeof(bool), typeof(MainWindow));


        public MainWindow()
        {
            InitializeComponent();
            bl = BlApi.Factory.Get;
        }

        /// <summary>
        /// when you click on the "manager" in the main window the main product window will open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainProduct(object sender, RoutedEventArgs e)
        {
            new MainManager().Show();
        }

        private void MainClient(object sender, RoutedEventArgs e)
        {
            new mainClient().Show();
        }

        private void OrderTracking(object sender, RoutedEventArgs e)
        {
            new OrderTrackingWindow().Show();   
        }

        private void Simulator(object sender, RoutedEventArgs e)
        {
            _simulatorClick = false;
            new SimulatorWindow(() => _simulatorClick = !_simulatorClick).Show();
        }
    }
}
