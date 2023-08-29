using DO;
namespace Dal;
internal static class DataSource
{
    static DataSource()
    {
        sInitialize();
    }

    internal readonly static Random rand = new();
    internal static List <Product?> productArr = new List <Product?>();
    internal static List<Order?> OrderArr = new List<Order?>();
    internal static List <OrderItem?> OrderItemArr = new List <OrderItem?>();
    internal static int countOfProductArry = 0;


    internal static int _nextIdOreder = 1000;
    internal static int _nextIdOrederItem = 1000;

    private static void CreateProducts()
    {
        string[] namesArr = new string[] { "meri", "lihi", "yellowJacket", "blueJacket", "StripedShirt", "WhiteShirt", "jeans", "Shorts", "ElegantPpants", "ClassicPants" };//contune to add more 8 

        Category[] categoriesArr = new Category[] { Category.Dresses, Category.Dresses, Category.jackets, Category.jackets, Category.Shirts, Category.Shirts, Category.pants, Category.pants, Category.pants, Category.pants };

        for (int i = 0; i < 10; i++)
        {
            Product product = new Product();
            product.ID = rand.Next(100000, 1000000);
            product.Name = namesArr[i];
            product.inStock = i * 5;
            product.Price = rand.Next(50, 300);
            product.Category = categoriesArr[i];
            productArr.Add(product);
        }
    }



    private static void CreateOrder()
    {
        string[] costumerNameArr = new string[] {"Hadas Zehevi","Avigail Cohen","Avigail Levi","Efrat Avitan" ,
            "Ayala Nisani","Shira kubin","Teheila yahav","Gefen Shalom","Yair Macluf","Avishag Hazan",
        "Mical shooshan","Nati Segal","Yahakov Avidan","Meir Cohen","Avishai Shitrit","Nati Levi","ronit chaim","shira chaim","hadar levi","chana refi"};
        string[] costumerAdress = new string[] { "Atehena 5 Elad", "Hashoshana 47 Givataim" , "Atehena 48 Elad", "Hashoshana 37 Givataim","rabi akiva 9","hashoshana 4" ,"Atehena 5 Elad", "Hashoshana 47 Givataim" , "Atehena 48 Elad","karo 6 ", "Atehena 5 Elad", "Hashoshana 47 Givataim", "Atehena 48 Elad", "Hashoshana 37 Givataim", "rabi akiva 9", "hashoshana 4", "rabi akiva 19", "hashoshana 47", "rabi akiva 99", "hashoshana 40" };//ass more names
        int AmountOfOrders = 20;
        int days=rand.Next(10,20);
        for (int i = 0; i < AmountOfOrders; i++)
        {
            Order order = new Order();
            order.OrderID = _nextIdOreder++;
            order.CustomerName = costumerNameArr[i];
            order.CustomerEmail = costumerNameArr[i] + "@gmail.com";
            order.OrderDate = DateTime.Now.AddDays(-days);
            order.CustomerAdress = costumerAdress[i];
            order.OrderShipDate = null;
            order.OrderDeliveryDate = null;
            if (i < AmountOfOrders * 0.4)
            {
                days = rand.Next(10, 20);
                TimeSpan shipTime = new TimeSpan(days, 0, 0, 0);
                order.OrderShipDate = order.OrderDate + shipTime;
            }
            if (i < AmountOfOrders * 0.48*0.6)
            {
                days = rand.Next(1, 10);
                TimeSpan deliverTime = new TimeSpan(days, 0, 0, 0);
                order.OrderDeliveryDate = order.OrderShipDate + deliverTime;
            }
            OrderArr.Add(order);
        }
    }
    private static void CreateOrderItem()
    {
        int index1, index2;
        for (int i = 0; i < 20; i++)
        {
            index1 = rand.Next(1, 5);
            for (int j = 0; j < index1; j++)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.ID = _nextIdOrederItem++;
                orderItem.Amount = rand.Next(1, 4);
                index2 = rand.Next(0,10);
                orderItem.ProductID = productArr[index2]?.ID ?? 0;
                orderItem.OrderID = OrderArr[i]?.OrderID ?? 0;
                orderItem.Price = productArr[index2]?.Price* orderItem.Amount ?? 0;
                OrderItemArr.Add(orderItem); 
            }
        }
    }

    private static void sInitialize()
    {
        CreateProducts();
        CreateOrder();
        CreateOrderItem();
        XmlTools.SaveListToXMLSerializer(OrderArr, @"..\xml\Orders.xml");
        XmlTools.SaveListToXMLSerializer(productArr, @"..\xml\Products.xml");
        XmlTools.SaveListToXMLSerializer(OrderItemArr, @"..\xml\OrderItems.xml");
    }
}







