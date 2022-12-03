using DO;
using static Dal.DataSource;
namespace Dal;
using DalApi;

internal class DalOrderItem:IOrderItem
{

    public int Add(OrderItem newOrderItem)
    {
        newOrderItem.ID = DataSource._nextIdOrederItem++;
        OrderItemArr.Add(newOrderItem);
        return newOrderItem.ID;
    }


    public  void Update(OrderItem order)
    {
        int index = OrderItemArr.FindIndex(x => x?.ID == order.ID);
        if (index == -1)
            throw new Exception();
        OrderItemArr[index] = order;
    }


    public  void Delete(int id)
    {

        int index = OrderItemArr.FindIndex(x => x?.ID == id);
        if (index == -1)
            throw new Exception();
        OrderItemArr.RemoveAt(index);
    }

    public  OrderItem? Get(int id)
    {

        return OrderItemArr.Find(x => x?.ID == id);
    }

    public  IEnumerable<OrderItem?> GetAll()
    {
        IEnumerable<OrderItem?> list = OrderItemArr.ToList();
        return list;

    }

}