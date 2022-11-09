using DO;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;

internal static class DataSource
{
    static DataSource()
    {
        s_Initialize();
    }
    private static readonly Random s_rand = new();

    internal static class Config
    {
        internal const int s_stratOrderNumber = 1000;
        private static int s_nextOrderNumber = s_stratOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }
    }
    internal static List<Product> ProductsList { get; }= new List<Product>();
    internal static List<Order> OrdersList { get; } = new List<Order>();
    internal static List<OrderItem> OrderItemList { get; } = new List<OrderItem>();

    private static void s_Initialize()
    {
        creatAndInitProducts();
        creatAndInitOrders();
        creatAndInitOrderItems();
    }
    private static void creatAndInitProducts()
    {
        for(int i=0;i<10;i++)
        {
            ProductsList.Add(
                new Product
                {
                    ID = i,
                    Name = "pppp",
                    Price = s_rand.Next(200),
                    Category= (Category)s_rand.Next(4),
                    inStock=s_rand.Next(50),
                });
                
        }
    }
}
