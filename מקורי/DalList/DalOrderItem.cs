using DO;

namespace Dal;

public class DalOrderItem
{

    public static int Add(OrderItem newOrderItem)
    {
        int x = (DataSource.s_nextOrderItemNumber) - 1000;
        newOrderItem.ID = DataSource.NextOrderItemNumber;
        DataSource.OrderItemArr[x] = newOrderItem;
        return newOrderItem.ID;
    }


    public static void Update(OrderItem order)
    {
        // DataSource.OrderItemArr.Length;
        bool x = false;
        for (int i = 0; i <= DataSource.s_nextOrderItemNumber; i++)
        {
            if (DataSource.OrderItemArr[i].ID == order.ID)
            {
                x = true;
                DataSource.OrderItemArr[i] = order;
            }
        }
        if (x == false)
            throw new Exception("cannot update an OrderItem, that is not exists");

    }


    public static void Delete(int id)
    {
        bool flag = false;

        for (int i = 0; i <= DataSource.OrderItemArr.Length; i++)
        {
            if (DataSource.OrderItemArr[i].ID == id)
            {
                DataSource.OrderItemArr[i] = DataSource.OrderItemArr[DataSource.s_nextOrderItemNumber];
                DataSource.s_nextOrderItemNumber--;
                flag = true;
            }
        }
        if (flag == false)
            throw new Exception("cannot delete an OrderItem,that is not exists");
    }




    public static OrderItem Get(int id)
    {

        for (int i = 0; i <= DataSource.OrderItemArr.Length; i++)
        {
            if (DataSource.OrderItemArr[i].ID == id)

                return DataSource.OrderItemArr[i];

        }

        throw new Exception("the OrderItem does not exist");

    }


    public static OrderItem[] allOrderItem()
    {
        OrderItem[] Arr = new OrderItem[DataSource.OrderItemArr.Length];
        for (int i = 0; i < DataSource.s_nextOrderItemNumber; i++)
            Arr[i] = DataSource.OrderItemArr[i];
        return Arr;


    }











}