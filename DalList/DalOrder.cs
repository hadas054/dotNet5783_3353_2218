using DO;

namespace Dal;
public class DalOrder
{
    public static int Add(Order newOrder)   //אילה אמרה שאולי לא צריך להכניס פה ערך לפי ההוראות
    {
        newOrder.OrderID = DataSource._nextIdOreder++;
        DataSource.OrderArr[DataSource._nextEmptyOreder] = newOrder;
        DataSource._nextEmptyOreder++;
        return newOrder.OrderID;
    }

    public static Order Get(int id)
    {

        for (int i = 0; i <= DataSource._nextEmptyOreder; i++)
        {
            if (DataSource.OrderArr[i].OrderID == id)
                return DataSource.OrderArr[i];
        }
        throw new Exception("the OrderItem does not exist");

    }


    public static Order[] allOrders()
    {
        Order[] Arr = new Order[DataSource._nextEmptyOreder];
        for (int i = 0; i < DataSource._nextEmptyOreder; i++)
            Arr[i] = DataSource.OrderArr[i];
        return Arr;
    }

    public static void Delete(int id)
    {
        for (int i = 0; i <= DataSource._nextEmptyOreder; i++)
        {
            if (DataSource.OrderArr[i].OrderID == id)
            {
                DataSource.OrderArr[i] = DataSource.OrderArr[DataSource._nextEmptyOreder - 1];
                DataSource._nextEmptyOreder--;
                return;
            }
        }
            throw new Exception("cannot delete an OrderItem,that is not exists");
    }


    public static void Update(Order order)
    {
        for (int i = 0; i < DataSource._nextEmptyOreder; i++)
        {
            if (DataSource.OrderItemArr[i].ID == order.OrderID)
            {
                DataSource.OrderArr[i] = order;
                return;
            }
        }
            throw new Exception("cannot update an Order, that is not exists");

    }

}

