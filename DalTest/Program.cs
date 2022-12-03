using Dal;
using DalApi;
using DO;
namespace DalTest;
public class porgram
{

    static IDal dal = new DalList();
    public static void ProductFunc()
    {
        char ch;
        Console.WriteLine(@"
a: Add product
b: Get product byID
c: Get products' list
d: Update product
e: Delete product
");
        ch = Convert.ToChar(Console.ReadLine());

        do
        {
            try
            {
                switch (ch)
                {
                    case 'a':
                        Product p = new Product();
                        Console.WriteLine("Enter the name of the product");
                        p.Name = Console.ReadLine();
                        Console.WriteLine("Enter the stock of the product");
                        p.inStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the product");
                        p.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the category of the product");
                        p.Category = (Category)Convert.ToInt32(Console.ReadLine());
                        dal.Product.Add(p);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of product");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(dal.Product.Get(id));
                        break;
                    case 'c':
                        IEnumerable<Product?> ProductsList = dal.Product.GetAll();
                        foreach (Product? item in ProductsList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 'd':
                        Product p1 = new Product();
                        Console.WriteLine("Enter the Id of the product to update");
                        p1.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the product");
                        p1.Name = Console.ReadLine();
                        Console.WriteLine("Enter the stock of the product");
                        p1.inStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price of the product");
                        p1.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the category of the product");
                        p1.Category = (Category)Convert.ToInt32(Console.ReadLine());
                        dal.Product.Update(p1);
                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of product to delete");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        dal.Product.Delete(Id);
                        break;
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(@"
a: Add product
b: Get product byID
c: Get products' list
d: Update product
e: Delete product
");
            ch = Convert.ToChar(Console.ReadLine());
        }
        while (ch != 'f');
    }

    public static void OrderFunc()
    {
        char ch;

        do
        {
            Console.WriteLine(@"
a: Add order 
b: Get order byID
c: Get order list
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
                        dal.Order.Add(o);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of customer");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(dal.Order.Get(id));
                        break;
                    case 'c':
                        IEnumerable<Order?> OrderList = dal.Order.GetAll();
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
                            dal.Order.Update(o);

                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of order to delete");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        dal.Order.Delete(Id);
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
        while (ch != 'f');
    }

    public static void OrderItemFunc()
    {
        char ch;

        do
        {
            Console.WriteLine(@"
a: Add order item
b: Get order item byID
c: Get order items' list
d: Update order item
e: Delete order item
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
                        dal.OrderItem.Add(items);
                        break;
                    case 'b':
                        Console.WriteLine("Enter the ID of order");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(dal.OrderItem.Get(Id));
                        break;
                    case 'c':
                        IEnumerable< OrderItem?> OrderItemList = dal.OrderItem.GetAll();
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
                        dal.OrderItem.Update(items);
                        break;
                    case 'e':
                        Console.WriteLine("Enter the ID of order to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        dal.OrderItem.Delete(id);
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

    


    static void Main(string[] args)
    {
        int ch = 0;
        Console.WriteLine("Press 1 for product, 2 for order, 3 for orderItem, 4 for exit");
        ch = Convert.ToInt32(Console.ReadLine());
        while (ch != 4) 
        {
            switch (ch)
            {
                case 1:
                    ProductFunc();
                    break;
                case 2:
                    OrderFunc();
                    break;
                case 3:
                    OrderItemFunc();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press 1 for product, 2 for order, 3 for orderItem, 4 for exit");
            ch = Convert.ToInt32(Console.ReadLine());

        }
    }
}
