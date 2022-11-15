using DO;
using System;
using System.Security.Cryptography.X509Certificates;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Data;

namespace Dal;

internal static class DataSource
{
    //private static readonly Random s_rand = new();
    public readonly static Random rand = new Random(DateTime.Now.Millisecond);

    static DataSource()
    {
        s_Initialize();//מתודה פרטית שמזומנת מבנאי ברירת המחדל הסטטי של המחלקה
    }

    internal static Product[] productArr = new Product[50];
    internal static int countOfProductArry = 0;


    internal static Order[] OrderArr = new Order[100];
    internal static OrderItem[] OrderItemArr = new OrderItem[200];



    internal static class Config
    {
        internal const int s_stratOrderNumber = 1000;

        internal static int s_nextOrderNumber = s_stratOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }


        internal static int s_nextOrderItemNumber = s_stratOrderNumber;
        internal static int NextOrderItemNumber { get => s_nextOrderItemNumber++; }

    }



    private static void s_Initialize()
    {
        CreateProducts();
        CreateOrder();
        CreateOrderItem();
    }

    

    private static void CreateProducts()
    {
        string[] namesArr = new string[] {"meri","lihi", "yellowJacket", "blueJacket", "StripedShirt", "WhiteShirt", "jeans", "Shorts", "ElegantPpants", "ClassicPants" };//contune to add more 8 

        Category[] categoriesArr = new Category[] { Category.Dresses,Category.Dresses,Category.jackets,Category.jackets,Category.Shirts,Category.Shirts,Category.pants,Category.pants,Category.pants,Category.pants};
        
        for(int i=0;i<10;i++)
        {
            Product product = new Product();
            //product.ID = 100000 + i;
            product.ID=rand.Next(100000,999999);
            product.Name=namesArr[i];
            product.inStock = i*5;
            product.Price = rand.Next(50, 300);
            product.Category = categoriesArr[i];
             productArr[i]=product;   //  לבדוק אם ככה מכניסים
            //Product.Add(product);  //למה הוא לא נותן

        }
     }



    private static void CreateOrder()
    {
        string[] costumerNameArr = new string[] {"Hadas Zehevi","Avigail Cohen","Avigail Levi","Efrat Avitan" ,
            "Ayala Nisani","Shira kubin","Teheila yahav","Gefen Shalom","Yair Macluf","Avishag Hazan",
        "Mical shooshan","Nati Segal","Yahakov Avidan","Meir Cohen","Avishai Shitrit","Nati Levi"};

        string[] costumerAdress = new string[] { "Atehena 5 Elad","Hashoshana 47 Givataim"};//ass more names



        int AmountOfOrders = 20;
        for (int i = 0; i < AmountOfOrders; i++)
        {
           Order order = new Order();
            order.OrderID = Config.NextOrderNumber;
            order.CustomerName = costumerNameArr[i];
            order.OrderDate = DateTime.Now.AddMonths(rand.Next(-4, -1));
            //if (i <= AmountOfOrders * 0.8)
            //    order.OrderShipDate=order.OrderDate.

            order.CustomerEmail=costumerNameArr[i]+"@gmail.com";
            order.CustomerAdress = costumerAdress[i];
         order.OrderShipDate = DateTime.Now.AddMonths(rand.Next(-4, -1));   //fixxxxxxxx
            order.OrderDeliveryDate = DateTime.Now.AddMonths(rand.Next(-4, -1));//fixxxxxxxxx


        }
    }



    private static void CreateOrderItem()
    {

        int helpId = rand.Next(productArr.First().ID, productArr.Last().ID);
        OrderItem item = new OrderItem();
        item.ID = Config.NextOrderItemNumber;
        item.ProductID = helpId;
        item.Amount = rand.Next(5);
        item.Price = rand.Next(50, 400);
        //item.OrderID=

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
