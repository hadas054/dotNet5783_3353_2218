using DO;

namespace Dal;
public class DalOrder
{
    public static int Add(Order newOrder)   //אילה אמרה שאולי לא צריך להכניס פה ערך לפי ההוראות
    {
        int x = (DataSource.s_nextOrderNumber) - 1000;
        newOrder.OrderID = DataSource.NextOrderNumber;
        DataSource.OrderArr[x] = newOrder;
        return newOrder.OrderID;
    }




    public static Order Get(int id)
    {

        for (int i = 0; i <= DataSource.s_nextOrderNumber; i++)
        {
            if (DataSource.OrderArr[i].OrderID == id)
                return DataSource.OrderArr[i];
        }
        throw new Exception("the OrderItem does not exist");

    }


    public static Order[] allOrders()
    {
        Order[] Arr = new Order[DataSource.s_nextOrderNumber];
        for (int i = 0; i < DataSource.s_nextOrderNumber; i++)
            Arr[i] = DataSource.OrderArr[i];
        return Arr;
    }

    public static void Delete(int id)
    {
        bool flag = false;

        for (int i = 0; i <= DataSource.s_nextOrderNumber; i++)
        {
            if (DataSource.OrderArr[i].OrderID == id)
            {
                DataSource.OrderArr[i] = DataSource.OrderArr[DataSource.s_nextOrderNumber];
                DataSource.s_nextOrderNumber++;
                flag = true;
            }
        }
        if (flag == false)
            throw new Exception("cannot delete an OrderItem,that is not exists");
    }


    public static void Update(Order order)
    {
        // DataSource.OrderItemArr.Length;
        bool x = false;
        for (int i = 0; i <= DataSource.s_nextOrderNumber; i++)
        {
            if (DataSource.OrderItemArr[i].ID == order.OrderID)
            {
                x = true;
                DataSource.OrderArr[i] = order;
            }
        }
        if (x == false)
            throw new Exception("cannot update an Order, that is not exists");

    }

}

