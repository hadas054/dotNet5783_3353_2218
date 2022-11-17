using Dal;
using DO;
namespace DalTest
{
    public class Program
    {
<<<<<<< HEAD
        private static DalProduct DalProduct = new DalProduct();
        private static DalOrder DalOrder = new DalOrder();
        private static DalOrderItem DalOrderItem = new DalOrderItem();
        static void Main(String[] args)
=======

        char ch;

        do
>>>>>>> e4d9cb837dac333d7fab6b2175d7fcebf8fabfce
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

                                    orderItem.Price = Dal.DalProduct.Get(orderItem.ProductID).Price;
                                    Console.WriteLine("enter amount of orderItem");
                                    int.TryParse(Console.ReadLine(), out amount);
                                    orderItem.Amount = amount;
                                    Dal.DalOrderItem.Add(orderItem);
                                    break;
                                case 2:
                                    Console.WriteLine("enter id of orderItem");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Console.WriteLine(Dal.DalOrderItem.Get(id));
                                    break;
                                case 3:
                                    OrderItem[] ord = DalOrderItem.allOrderItem();
                                    foreach (OrderItem o in ord)
                                    {
                                        Console.WriteLine(o);
                                    }
                                    break;
                                case 4:
                                    OrderItem orderItem1 = new OrderItem();
                                    Console.WriteLine("enter id of orderItem");
                                    int.TryParse(Console.ReadLine(), out id);
                                    orderItem1.ID = id;
                                    Console.WriteLine("enter product ID of orderItem");
                                    int.TryParse(Console.ReadLine(), out idProduct);
                                    orderItem1.ProductID = idProduct;
                                    Console.WriteLine("enter order ID of orderItem");
                                    int.TryParse(Console.ReadLine(), out idOrder);
                                    orderItem1.OrderID = idOrder;

                                    orderItem1.Price = Dal.DalProduct.Get(orderItem1.ProductID).Price;
                                    Console.WriteLine("enter amount of orderItem");
                                    int.TryParse(Console.ReadLine(), out amount);
                                    orderItem1.Amount = amount;
                                    if (orderItem1.ProductID > 0)
                                        Dal.DalOrderItem.Update(orderItem1);
                                    break;
                                case 5:
                                    Console.WriteLine("enter id of orderItem");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Dal.DalOrderItem.Delete(id);
                                    break;
                            }
                            break;
                    }
                }
                catch (Exception str)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("Choose an entity:");
                Console.WriteLine("0: to exit");
                Console.WriteLine("1: to product");
                Console.WriteLine("2: to order");
                Console.WriteLine("3: to orderItem");
                int.TryParse(Console.ReadLine(), out chooseEntity);

            }
        }
    }
}