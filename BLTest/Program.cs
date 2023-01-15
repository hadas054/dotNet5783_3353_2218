using BO;
using BlApi;
using BLImplementation;
using DO;
using System.Security.Cryptography;

class Program
{
    static IBL bl = Factory.Get;
    static Cart cart = new Cart();
    static void Main(string[] args)
    {
        string action = null;

        do
        {
            Console.WriteLine(@"
please choose the topic:
a: product
b: cart
c: order
d:exit");
            action = Console.ReadLine();
            try
            {
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
                        Console.WriteLine("have a nice day");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        while (action != "d");
    }


    static void ProductTest()
    {
        string action = null;
        BO.Product product = new BO.Product();
        while (true)
        {
            Console.WriteLine(@"choose the action:
a: add product
b: delete product
c: get product client
d: get products
e: update
f: get product manager
g: return
");
            action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "a":
                        Console.WriteLine("enter Name:\n");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("enter price:\n");
                        product.Price = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter id:\n");
                        product.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter instock:\n");
                        product.Instock = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter category:\n");
                        product.Category = (BO.Category)int.Parse(Console.ReadLine());
                        bl.Product.AddProduct(product);
                        break;

                    case "b":
                        Console.WriteLine("Enter id of the product");
                        int id = int.Parse(Console.ReadLine());
                        bl.Product.Delete(id);
                        break;
                    case "c":
                        Console.WriteLine("Enter id of the product");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.Product.GetProductC(id));
                        break;
                    case "d":
                        var v = bl.Product.GetProducts();
                        foreach (var item in v)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "e":
                        Console.WriteLine("enter Name:\n");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("enter price:\n");
                        product.Price = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter id:\n");
                        product.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter instock:\n");
                        product.Instock = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter category:\n");
                        product.Category = (BO.Category)int.Parse(Console.ReadLine());
                        bl.Product.Update(product);
                        break;
                    case "f":
                        Console.WriteLine("enter id:\n");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.Product.GetProductM(id));
                        break;
                    case "g":
                        return;
                    default:
                        Console.WriteLine("Error");
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
            Console.WriteLine(@"
choose the action:
a: add product
b: update amount of the product
c: delete product
d: clear the cart
e: order confirmation
f: return to the main menu");

            action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "a":
                        Console.WriteLine("Enter the id of the product that you wanna add");
                        int Id = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.cart.AddProduct(cart, Id));
                        break;

                    case "b":
                        Console.WriteLine("Enter the id of the product that you wanna update");
                        Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new amount");
                        int newAmount = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.cart.UpdateAmount(cart, Id, newAmount));
                        break;
                    case "c":
                        Console.WriteLine("Enter the id of the product that you wanna delete");
                        Id = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.cart.UpdateAmount(cart, Id, 0));
                        break;
                    case "d":
                        cart.Items.Clear();
                        break;
                    case "e":
                        Console.WriteLine("Enter your name");
                        string s = Console.ReadLine();
                        cart.CustomerName = s;
                        Console.WriteLine("Enter your adress");
                        s = Console.ReadLine();
                        cart.CustomerAddress = s;
                        Console.WriteLine("Enter your Email");
                        s = Console.ReadLine();
                        cart.CustomerEmail = s;
                        bl.cart.OrderConfirmation(cart);
                        cart.Items.Clear();//איפוס הסל
                        return;
                    case "f":
                        return;
                    default:
                        Console.WriteLine("Error");
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

    static void OrderTest()
    {
        string action = null;
        BO.Order order = new BO.Order();
        while (true)
        {
            //כאן תבקשי קלט מהמשתמש

            Console.WriteLine(@"
a: update order
b: get order
c: delivery order
d: get orders
e: sent order
f: order tracking
");
            action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "a":
                        order = bl.Order.UpdateOrder();
                        Console.WriteLine(order);
                        break;

                    case "b":
                        Console.WriteLine("Enter the id");
                        int id = int.Parse(Console.ReadLine());
                        order = bl.Order.GetOrder(id);
                        Console.WriteLine(order);
                        break;

                    case "c":
                        Console.WriteLine("Enter the id of the product");
                        id = int.Parse(Console.ReadLine());
                        order = bl.Order.DeliveredOrder(id);
                        Console.WriteLine(order);
                        break;
                    case "d":
                        IEnumerable<OrderForList?> v = bl.Order.GetOrders();
                        foreach (var item in v)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "e":
                        Console.WriteLine("Enter the id");
                        id = int.Parse(Console.ReadLine());
                        order = bl.Order.SentOrder(id);
                        Console.WriteLine(order);
                        break;
                    case "f":
                        Console.WriteLine("Enter the id");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(bl.Order.OrderTracking(id));
                        break;
                    default:
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }



}

