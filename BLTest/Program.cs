using BO;
using BlApi;
using BLImplementation;
using DO;
using System.Security.Cryptography;

class Program
{
    static IBL bl = new BL();
    static Cart cart = new Cart();
    static void Main(string[] args)
    {
        string action = null;

        do
        {
            //כאן תבקשי קלט מהמשתמש
            Console.WriteLine(@"
please choose the topic:
a: product
b: cart
c: order
d:exit");
            action=Console.ReadLine();

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
        while(action != "d");
    }





    static void ProductTest()
    {
        string action = null;
       BO. Product product = new BO.Product();
        while (true)
        {
            //כאן תבקשי קלט מהמשתמש
            Console.WriteLine(@"choose the action:
a: add product
b: delete product
c: get product
d: get products
e: update
");
            switch (action)
            {
                case "a":
                    bl.Product.AddProduct(product);
                    break;

                case "b":
                    Console.WriteLine("Enter id of the product");
                    int id=int.Parse(Console.ReadLine());
                    bl.Product.Delete(id);
                    break;
                    //תכניסי את כל הפונקציות
                case "c":
                    Console.WriteLine("Enter id of the product");
                    id = int.Parse(Console.ReadLine());
                    bl.Product.GetProductC(id);
                    break;
                case "d":
                   var v= bl.Product.GetProducts;
                    foreach (var item in v)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "e":
                    bl.Product.Update(product);

                    break;
                default :
                    Console.WriteLine("Error");
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
            Console.WriteLine(@"
choose the action:
a: add product
b: update amount of the product
c: delete product
d: clear the cart
e: order confirmation
f: return to the main menu"); 


            switch (action)
            {
                case "a":
                    Console.WriteLine("Enter the id of the product that you wanna add");
                    int Id=int.Parse(Console.ReadLine());
                    bl.cart.AddProduct(cart, ID);
                    break;

                case "b":
                    Console.WriteLine("Enter the id of the product that you wanna update");
                     Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new amount");
                    int newAmount=int.Parse(Console.ReadLine());
                    bl.cart.UpdateAmount(cart, ID, newAmount);
                    break;

                case "c":
                    Console.WriteLine("Enter the id of the product that you wanna delete");
                    Id=int.Parse(Console.ReadLine());
                    bl.cart.UpdateAmount(cart, Id, 0);
                    break;
                case "d":
                    cart.Items.Clear();
                    break;
                case "e":
                    Console.WriteLine("Enter your name");
                    string s=Console.ReadLine();
                    cart.CustomerName = s;
                    Console.WriteLine("Enter your adress");
                    s=Console.ReadLine();
                    cart.CustomerAddress= s;
                    Console.WriteLine("Enter your Email");
                    s = Console.ReadLine();
                    cart.CustomerEmail= s;
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

    }

    static void OrderTest()
    {
        string action = null;

        while (true)
        {
            //כאן תבקשי קלט מהמשתמש

            Console.WriteLine(@"
a: update order
b: get order
c: delivery order
d: det orders
e:sent order");
            switch (action)
            {
                case "a":
                    bl.Order.UpdateOrder();
                    break;

                case "b":
                    Console.WriteLine("Enter the id");
                    int id = int.Parse(Console.ReadLine());
                    bl.Order.GetOrder(id);
                    break;

                //תכניסי את כל הפונקציות
                case "c":
                    Console.WriteLine("Enter the id of the product");
                    id=int.Parse(Console.ReadLine());
                    bl.Order.SentOrder(id);
                    break;
                case "d":
                    var v = bl.Order.GetOrders;
                    foreach(var item in v)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                 case "e":
                    Console.WriteLine("Enter the id");
                    id = int.Parse(Console.ReadLine());



               
                    break;
                    return;

            }
        }

    }



}

