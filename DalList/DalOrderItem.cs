using DO;

namespace Dal;

public class DalOrderItem
{

    public static int Add(OrderItem newOrderItem)
    {
        newOrderItem.ID = DataSource._nextIdOrederItem++;
        DataSource.OrderItemArr[DataSource._nextEmptyOrederItem++] = newOrderItem;
        return newOrderItem.ID;
    }


    public static void Update(OrderItem order)
    {
        bool x = false;
        for (int i = 0; i <= DataSource.OrderItemArr.Length; i++)
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

        for (int i = 0; i <= DataSource.OrderItemArr.Length; i++)
        {
            if (DataSource.OrderItemArr[i].ID == id)
            {
                DataSource.OrderItemArr[i] = DataSource.OrderItemArr[--DataSource._nextEmptyOrederItem];
                return;
            }
        }

        throw new Exception("cannot delete an OrderItem,that is not exists");
    }




    public static OrderItem Get(int id)
    {

        for (int i = 0; i <= DataSource._nextEmptyOrederItem; i++)
        {
            if (DataSource.OrderItemArr[i].ID == id)

                return DataSource.OrderItemArr[i];

        }

        throw new Exception("the OrderItem does not exist");

    }


    public static OrderItem[] allOrderItem()
    {
        OrderItem[] Arr = new OrderItem[DataSource._nextEmptyOrederItem];
        for (int i = 0; i < DataSource._nextEmptyOrederItem; i++)
            Arr[i] = DataSource.OrderItemArr[i];
        return Arr;


    }











}