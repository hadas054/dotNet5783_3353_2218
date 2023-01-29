using Dal;
using DalApi;

namespace Dal
{
    public class DalXml :IDal
    {
        public DalXml() { }
        public static IDal Instance { get; } = new DalXml();
        public IProduct Product { get; } = new DalProduct();
        public IOrder Order { get; } = new DalOrder();
        public IOrderItem OrderItem { get; } = new DalOrderItem();

    }
}