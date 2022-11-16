using System.Security.Cryptography.X509Certificates;
using Dal;
using DO;
namespace DalTest;

public class porgram
{
    public static void ProductFunc(DalProduct product)
    {

        char ch;
        do
        {
            Console.WriteLine(@"
a: Add product
b: Get product byID
c: Get products' list
d: Update product
e: Delete product
");
            ch = Convert.ToChar(Console.ReadLine());
            Product p = new Product();
            try
            {
                switch (ch)
                {
                    case 'a':
                        Console.WriteLine("Enter the Id of the product");
                        p.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the product");
                        p.Name = Console.ReadLine();
                        Console.WriteLine("Enter the stock of the product");
                        p.inStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the product");
                        p.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the category of the product");
                        p.Category = (Category)Convert.ToInt32(Console.ReadLine());
                        DalProduct.Add(p);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of product");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(DalProduct.Get(id));
                        break;
                    case 'c':
                       Product[] ProductsList = DalProduct.allProducts();
                        foreach (Product? item in ProductsList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 'd':
                        Console.WriteLine("Enter the Id of the product to update");
                        p.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the product");
                        p.Name = Console.ReadLine();
                        Console.WriteLine("Enter the stock of the product");
                        p.inStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the product");
                        p.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the category of the product");
                        p.Category = (Category)Convert.ToInt32(Console.ReadLine());
                        DalProduct.Update(p);
                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of product to delete");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        DalProduct.Delete(Id);
                        break;

                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }

        }
        while (ch != 'f');
    }
    public static void OrderFunc(DalOrder order)
    {
        char ch;


        do
        {
            Console.WriteLine(@"
a: Add order
b: Get order byID
c: Get orders' list
d: Update order
e: Delete order
");
            ch = Convert.ToChar(Console.ReadLine());
            Order o = new Order();
            try
            {
                switch (ch)
                {
                    case 'a':
                        Console.WriteLine("Enter the name of customer");
                        o.CustomerName = Console.ReadLine();
                        Console.WriteLine("Enter the email of customer");
                        o.CustomerEmail = Console.ReadLine();
                        Console.WriteLine("Enter the adress of customer");
                        o.CustomerAdress = Console.ReadLine();
                        Console.WriteLine("Enter the ID of customer");
                        o.OrderID = Convert.ToInt32(Console.ReadLine());
                        o.OrderShipDate = null;
                        o.OrderDeliveryDate = null;
                        o.OrderDate = DateTime.Now;
                        DalOrder.Add(o);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of customer");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(DalOrder.Get(id));
                        break;
                    case 'c':
                        Order[] OrderList = DalOrder.allOrders();
                        foreach (Order? item in OrderList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 'd':
                        Console.WriteLine("Enter the name of customer to update");
                        o.CustomerName = Console.ReadLine();
                        Console.WriteLine("Enter the email of customer");
                        o.CustomerEmail = Console.ReadLine();
                        Console.WriteLine("Enter the adress of customer");
                        o.CustomerAdress = Console.ReadLine();
                        Console.WriteLine("Enter the ID of customer");
                        o.OrderID = Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine("Enter the ship date of customer");
                        o.OrderDate = DateTime.Now;
                        if (o.CustomerName.Length > 0)
                            Dal.DalOrder.Update(o);

                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of order to delete");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        DalOrder.Delete(Id);
                        break;
                }
            }

            catch (Exception s)
            {
                Console.WriteLine(s);
            }

        }
        while (ch != 'f');
    }
    public static void OrderItemFunc(DalOrderItem item)
    {
        char ch;

        do
        {
            Console.WriteLine(@"
a: Add order
b: Get order byID
c: Get orders' list
d: Update order
e: Delete order
");
            ch = Convert.ToChar(Console.ReadLine());
            OrderItem items = new OrderItem();
            try
            {
                switch (ch)
                {
                    case 'a':
                        Console.WriteLine("Enter the ID of order");
                        items.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ProductID of order");
                        items.ProductID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the orderID of order");
                        items.OrderID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the order");
                        items.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the amount of products in the order item");
                        items.Amount = Convert.ToInt32(Console.ReadLine());
                        DalOrderItem.Add(items);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of order");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(DalOrderItem.Get(Id));
                        break;
                    case 'c':
                        OrderItem[] OrderItemList = DalOrderItem.allOrderItem();
                        foreach (OrderItem? s in OrderItemList)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case 'd':
                        Console.WriteLine("Enter the ID of order to update");
                        items.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ProductID of order");
                        items.ProductID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the orderID of order");
                        items.OrderID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the order");
                        items.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the amount of products in the order item");
                        items.Amount = Convert.ToInt32(Console.ReadLine());
                        DalOrderItem.Update(items);
                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of order to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        DalOrderItem.Delete(id);
                        break;
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }


        }
        while (ch != 'f');
    }

    private static DalOrder order = new DalOrder();
    private static DalOrderItem orderItem = new DalOrderItem();
    private static DalProduct Product = new DalProduct();
    static void Main(string[] args)
    {

        int ch = 0;
        do
        {
            Console.WriteLine("Press 1 for product, 2 for order, 3 for orderItem, 4 for exit");
            ch = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (ch)
                {
                    case 1:
                        ProductFunc(Product);
                        break;
                    case 2:
                        OrderFunc(order);
                        break;
                    case 3:
                        OrderItemFunc(orderItem);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }

        }
        while (ch != 4);

    }
}