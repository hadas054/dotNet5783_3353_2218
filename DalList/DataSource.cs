using DO;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;

internal static class DataSource
{
    //private static readonly Random s_rand = new();
    public readonly static Random rand = new Random(DateTime.Now.Millisecond);

    static DataSource()
    {
        s_Initialize();//מתודה פרטית שמזומנת מבנאי ברירת המחדל הסטטי של המחלקה
    }

    internal static Product[] ProductArr = new Product[50];
    internal static int CountOfProductArry = 0;


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
        creatAndInitProducts();
        creatAndInitOrders();
        creatAndInitOrderItems();
    }
    private static void creatAndInitProducts()
    {
        for(int i=0;i<10;i++)
        {
            ProductsArr.Add(
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
