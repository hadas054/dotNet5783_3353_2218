

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public int Add(Order order)
    {

        //Read config file
        XElement configRoot = XElement.Load(configPath);
        var v = configRoot.Element("orderSeq");
        int nextSeqNum = Convert.ToInt32(configRoot.Element("orderSeq")!.Value);
        nextSeqNum++;

        order.OrderID = nextSeqNum;
        //update config file
        configRoot.Element("orderSeq")!.SetValue(nextSeqNum);
        configRoot.Save(configPath);


        XElement OrderID = new XElement("OrderID", order.OrderID);
        XElement CustomerName = new XElement("CustomerName", order.CustomerName);
        XElement CustomerEmail = new XElement("CustomerEmail", order.CustomerEmail);
        XElement CustomerAdress = new XElement("CustomerAdress", order.CustomerAdress);
        XElement OrderDate = new XElement("OrderDate", order.OrderDate);
        XElement OrderShipDate = new XElement("OrderShipDate", order.OrderShipDate);
        XElement OrderDeliveryDate = new XElement("OrderDeliveryDate", order.OrderDeliveryDate);
        XElement Order = new XElement("Order", OrderID, CustomerName, CustomerEmail, CustomerAdress, OrderDate, OrderShipDate, OrderDeliveryDate);

        ordersRoot.Add(Order);
        ordersRoot.Save(path);


        return order.OrderID;

    }

    //string path = @"..\xml\orders.xml";
    //string configPath = @"..\xml\config.xml";
    ////string dir = @"..\bin\xml\";


    //XElement ordersRoot;

    //public DalOrder()
    //{
    //    LoadData();
    //}

    //private void LoadData()
    //{
    //    //try
    //    //{
    //    //if (!File.Exists(path))
    //    //    throw new Exception("order File upload problem");
    //    // else
    //    //    {
    //    //        ordersRoot = new XElement("orders");
    //    //        ordersRoot.Save( path);
    //    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{

    //    //}
    //    //}

    //    if (!File.Exists(path))
    //        throw new Exception("order File upload problem");
    //    else
    //    {
    //        ordersRoot = new XElement("orders");
    //        ordersRoot.Save(path);
    //    }
    //}

    //    public int Add(Order order)
    //{

    //    //Read config file
    //    XElement configRoot = XElement.Load(configPath);
    //    var v = configRoot.Element("orderSeq");
    //    int nextSeqNum = Convert.ToInt32(configRoot.Element("orderSeq")!.Value);
    //    nextSeqNum++;

    //    order.ID = nextSeqNum;
    //    //update config file
    //    configRoot.Element("orderSeq")!.SetValue(nextSeqNum);
    //    configRoot.Save(configPath);


    //    XElement Id = new XElement("Id", order.ID);
    //    XElement CustomerName = new XElement("CustomerName", order.CustomerName);
    //    XElement CustomerEmail = new XElement("CustomerEmail", order.CustomerEmail);
    //    XElement CustomerAdress = new XElement("CustomerAdress", order.CustomerAdress);
    //    XElement OrderDate = new XElement("OrderDate", order.OrderDate);
    //    XElement ShipDate = new XElement("ShipDate", order.ShipDate);
    //    XElement DeliveryDate = new XElement("DeliveryDate", order.DeliveryDate);


    //    ordersRoot.Add(new XElement("Order", Id, CustomerName, CustomerEmail, CustomerAdress, OrderDate, ShipDate, DeliveryDate));
    //    ordersRoot.Save(path);


    //    return order.ID;

    //}

    public void Delete(int id)
    {
        List<Order> ordeLst = XmlTools.LoadListFromXMLSerializer<Order>(path);
        int index = ordeLst.FindIndex(x => x.OrderID == id);
        if (index == -1)
            throw new NotExistException("The Order is't exist");

        ordeLst.RemoveAt(index);

        XmlTools.SaveListToXMLSerializer(ordeLst, path);
    }

    public Order GetByCondition(Func<Order?, bool>? cond)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where cond(item)
                select item).FirstOrDefault();
    }

    public IEnumerable<Order?> GetAll(Func<Order?, bool>? func = null)
    {
        List<DO.Order?> orderList = XmlTools.LoadListFromXMLSerializer<DO.Order?>(path);
        return func is null ? orderList : orderList.Where(func);
    }

    public Order Get(int id)
    {
        List<Order> prodLst = XmlTools.LoadListFromXMLSerializer<Order>(path);

        if (!prodLst.Exists(x => x.OrderID == id))
            throw new NotExistException("The Order is't exist");

        return (from item in XmlTools.LoadListFromXMLSerializer<Order>(path)
                where item.OrderID == id
                select item).FirstOrDefault();
    }

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

