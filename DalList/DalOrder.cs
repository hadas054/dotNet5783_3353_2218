using DO;

namespace Dal;

public class DalOrder  //iorder
{
    public int Add(Order neworder)
    {
        int x = (DataSource.Config.s_nextOrderNumber)-1000;
        neworder.OrderID = DataSource.Config.NextOrderNumber;
        DataSource.OrderArr[x] = neworder;                 
        return neworder.OrderID;     //    i need it?
    }
}

