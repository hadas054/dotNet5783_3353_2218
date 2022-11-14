
using DO;

namespace Dal;

public class DalOrderItem
{

    public int Add(OrderItem newOrderItem)
    {
        int x = (DataSource.Config.s_nextOrderItemNumber) - 1000;
        newOrderItem.ID = DataSource.Config.NextOrderItemNumber;
        DataSource.OrderItemArr[x]=newOrderItem;
        return newOrderItem.ID;   // i need it?
    }







}
