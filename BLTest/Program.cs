using BO;
using BlApi;
using BLImplementation;
class Program
{
    static IBL bl = new BL();
    static Cart cart = new Cart();
    static void Main(string[] args)
    {
        string action = null;

        while (true)
        {
            //כאן תבקשי קלט מהמשתמש
            switch (action)
            {
                case "a":
                    ProductTest();
                    break;

                case "b":
                    CartTest();
                    break;

                case "c":
                    OrderTest();
                    break;

                case "d":
                    return;

            }
        }
    }

    static void ProductTest()
    {
        string action = null;
        Product product = new Product();
        while (true)
        {
            //כאן תבקשי קלט מהמשתמש
            switch (action)
            {
                case "a":
                    bl.Product.AddProduct(product);
                    break;

                case "b":
                    bl.Product.GetProducts();
                    break;
                    //תכניסי את כל הפונקציות
                case "d":
                    return;

            }
        }

    }
    static void CartTest()
    {
        string action = null;
        int ID = 0;
        int amount = 0;
        while (true)
        {
            //כאן תבקשי קלט מהמשתמש
            switch (action)
            {
                case "a":
                    bl.cart.AddProduct(cart, ID);
                    break;

                case "b":
                    bl.cart.UpdateAmount(cart, ID, amount);
                    break;

                case "d":
                    bl.cart.OrderConfirmation(cart);
                    return;

            }
        }

    }

    static void OrderTest()
    {
        string action = null;

        while (true)
        {
            //כאן תבקשי קלט מהמשתמש
            switch (action)
            {
                case "a":
                    bl.Order.UpdateOrder();
                    break;

                case "b":
                    bl.Order.GetOrders();
                    break;
                //תכניסי את כל הפונקציות
                case "d":
                    return;

            }
        }

    }



}

