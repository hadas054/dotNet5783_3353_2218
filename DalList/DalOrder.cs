
using static Dal.DataSource;
using DalApi;
using DO;
using DalApi;

namespace Dal;

internal class DalOrder :IOrder
{
    public int Add(Order newOrder)   
    {
        newOrder.OrderID = DataSource._nextIdOreder++;
        DataSource.OrderArr.Add(newOrder);
        return newOrder.OrderID;
    }

    public Order? Get(int id)
    {

        return OrderArr.Find(x => x.Value.OrderID == id);
        //else throw exeption?

    }

    public IEnumerable<Order?> GetAll()
    {
        List<Order?> list = OrderArr.ToList();
        return list;
    }

    public void Delete(int id)
    {
        int index = OrderArr.FindIndex(x => x?.OrderID == id);
        if (index == -1)
            throw new Exception();
        OrderArr.RemoveAt(index);
    }

    public void Update(Order order)
    {
        int index = OrderArr.FindIndex(x => x?.OrderID == order.OrderID);
        if (index == -1)
            throw new Exception();
        OrderArr[index] = order;

    }

}

