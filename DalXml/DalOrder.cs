

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Dal;

internal class DalOrder : IOrder
{
    string path = @"..\xml\Orders.xml";
    string configPath = @"..\xml\config.xml";
    //string dir = @"..\bin\xml\";


    XElement ordersRoot;

    public DalOrder()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(path))
            throw new Exception("order File upload problem");
        else
        {
            ordersRoot = XElement.Load(path);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(Order order)
    {

        //Read config file
        XElement configRoot = XElement.Load(configPath);
        var v = configRoot.Element("orderSeq");
        int nextSeqNum = Convert.ToInt32(configRoot.Element("orderSeq")!.Value);
        order.OrderID = nextSeqNum++;
        //update config file
        configRoot.Element("orderSeq")!.SetValue(nextSeqNum);
        configRoot.Save(configPath);

        List<Order> orders = XmlTools.LoadListFromXMLSerializer<Order>(path);
        orders.Add(order);
        XmlTools.SaveListToXMLSerializer(orders, path);

        return nextSeqNum - 1;

    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        List<Order> ordeLst = XmlTools.LoadListFromXMLSerializer<Order>(path);
        int index = ordeLst.FindIndex(x => x.OrderID == id);
        if (index == -1)
            throw new NotExistException("The Order is't exist");

        ordeLst.RemoveAt(index);

        XmlTools.SaveListToXMLSerializer(ordeLst, path);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public Order GetByCondition(Func<Order?, bool>? cond)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where cond(item)
                select item).FirstOrDefault();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? func = null)
    {
        List<DO.Order?> orderList = XmlTools.LoadListFromXMLSerializer<DO.Order?>(path);
        return func is null ? orderList : orderList.Where(func);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public Order Get(int id)
    {
        List<Order> prodLst = XmlTools.LoadListFromXMLSerializer<Order>(path);

        if (!prodLst.Exists(x => x.OrderID == id))
            throw new NotExistException("The Order is't exist");

        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where item.OrderID == id
                select item).FirstOrDefault();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(Order Or)
    {
        List<Order> prodLst = XmlTools.LoadListFromXMLSerializer<Order>(path);

        if (!prodLst.Exists(x => x.OrderID == Or.OrderID))
            throw new NotExistException("The Order is't exist");

        int index = prodLst.FindIndex(x => x.OrderID == Or.OrderID);
        prodLst[index] = Or;
        XmlTools.SaveListToXMLSerializer(prodLst, path);
    }
}

