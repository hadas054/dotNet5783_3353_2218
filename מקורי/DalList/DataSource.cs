using DO;
namespace Dal;
internal static class DataSource
{
    //private static readonly Random s_rand = new();
    public readonly static Random rand = new();
    internal static Product[] productArr = new Product[50];
    internal static int countOfProductArry = 0;
    internal static Order[] OrderArr = new Order[100];
    internal static OrderItem[] OrderItemArr = new OrderItem[200];

    static DataSource()
    {
        s_Initialize();//מתודה פרטית שמזומנת מבנאי ברירת המחדל הסטטי של המחלקה
    }



    internal const int s_stratOrderNumber = 1000;
        internal static int s_nextOrderNumber = s_stratOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }
        internal static int s_nextOrderItemNumber = s_stratOrderNumber;
        internal static int NextOrderItemNumber { get => s_nextOrderItemNumber++; }
    private static void CreateProducts()
    {
        string[] namesArr = new string[] { "meri", "lihi", "yellowJacket", "blueJacket", "StripedShirt", "WhiteShirt", "jeans", "Shorts", "ElegantPpants", "ClassicPants" };//contune to add more 8 

        Category[] categoriesArr = new Category[] { Category.Dresses, Category.Dresses, Category.jackets, Category.jackets, Category.Shirts, Category.Shirts, Category.pants, Category.pants, Category.pants, Category.pants };

        for (int i = 0; i < 10; i++)
        {
            Product product = new Product();
            //product.ID = 100000 + i;
            product.ID = rand.Next(100000, 1000000);
            product.Name = namesArr[i];
            product.inStock = i * 5;
            product.Price = rand.Next(50, 300);
            product.Category = categoriesArr[i];
            productArr[i] = product;  //  לבדוק אם ככה מכניסים
            //DalProduct.Add(product);  //למה הוא לא נותן

        }
    }



    private static void CreateOrder()
    {
        string[] costumerNameArr = new string[] {"Hadas Zehevi","Avigail Cohen","Avigail Levi","Efrat Avitan" ,
            "Ayala Nisani","Shira kubin","Teheila yahav","Gefen Shalom","Yair Macluf","Avishag Hazan",
        "Mical shooshan","Nati Segal","Yahakov Avidan","Meir Cohen","Avishai Shitrit","Nati Levi","ronit chaim","shira chaim","hadar levi"};
        string[] costumerAdress = new string[] { "Atehena 5 Elad", "Hashoshana 47 Givataim" , "Atehena 48 Elad", "Hashoshana 37 Givataim","rabi akiva 9","hashoshana 4" ,"Atehena 5 Elad", "Hashoshana 47 Givataim" , "Atehena 48 Elad","karo 6 ", "Atehena 5 Elad", "Hashoshana 47 Givataim", "Atehena 48 Elad", "Hashoshana 37 Givataim", "rabi akiva 9", "hashoshana 4", "rabi akiva 19", "hashoshana 47", "rabi akiva 99", "hashoshana 40" };//ass more names
        int AmountOfOrders = 20;
        int days=rand.Next(10,20);
        for (int i = 0; i < AmountOfOrders; i++)
        {
            Order order = new Order();
            order.OrderID = 1;
            order.CustomerName = costumerNameArr[i];
            order.OrderDate = DateTime.Now.AddDays(-days);
            if (i < AmountOfOrders * 0.8)
            {
                days = rand.Next(10, 20);
                TimeSpan shipTime = new TimeSpan(days, 0, 0, 0);
                order.OrderShipDate = order.OrderDate + shipTime;
            }
            if (i < AmountOfOrders * 0.8*0.6)
            {
                days = rand.Next(1, 10);
                TimeSpan deliverTime = new TimeSpan(days, 0, 0, 0);
                order.OrderDeliveryDate = order.OrderShipDate + deliverTime;
            }
            order.CustomerEmail = costumerNameArr[i] + "@gmail.com";
            order.CustomerAdress = costumerAdress[i];
            order.OrderShipDate = DateTime.MinValue;   
            order.OrderDeliveryDate = DateTime.MinValue;
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
                orderItem.ID = 0;
                orderItem.Amount = rand.Next(1, 4);
                index2 = rand.Next(0,countOfProductArry);
                orderItem.ProductID = DataSource.productArr[index2].ID;
                orderItem.OrderID = DataSource.productArr[i].ID;
                orderItem.Price = DataSource.productArr[index2].Price;
                DalOrderItem.Add(orderItem);
            }
        }
    }

    private static void s_Initialize()
    {
        CreateProducts();
        CreateOrder();
        CreateOrderItem();
    }
}







//    private static void creatAndInitProducts()
//    {
//        for(int i=0;i<10;i++)
//        {
//            ProductsArr.Add(
//                new Product
//                {
//                    ID = i,
//                    Name = "pppp",
//                    Price = s_rand.Next(200),
//                    Category= (Category)s_rand.Next(4),
//                    inStock=s_rand.Next(50),
//                });

//        }
//    }
//}