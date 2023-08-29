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

namespace PL.client
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public static readonly IBL bl = Factory.Get;

        public static DependencyProperty CartDep =
          DependencyProperty.Register(nameof(Cart), typeof(Cart), typeof(CartWindow));
        Cart Cart { get => (Cart)GetValue(CartDep); set => SetValue(CartDep, value); }

        public CartWindow(Cart c)
        {
            Cart = c;
            InitializeComponent();
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            var selectProduct = (OrderItem)((Button)sender).Tag;
            string Action = ((Button)sender).Content.ToString()!;

            if (selectProduct != null)
                try
                {
                    Cart temp = null!;
                    switch (Action)
                    {
                        case "X":
                            temp = bl.cart.UpdateAmount(Cart, selectProduct!.ProductId, 0);
                            break;
                        case "+":
                            temp = bl.cart.UpdateAmount(Cart, selectProduct!.ProductId, selectProduct.Amount+1);
                            break;
                        case "-":
                            temp = bl.cart.UpdateAmount(Cart, selectProduct!.ProductId, selectProduct.Amount - 1);
                            break;
                    }

                    Cart = null!;
                    Cart = temp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void Confirm(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int ID = bl.cart.OrderConfirmation(Cart);
                MessageBox.Show($"the order ID is {ID}");
                Cart= null!;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
