using Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;

//short implementation with XMLTools functions
internal class DalProduct : IProduct
{
    string path = @"..\xml\Products.xml";
    string configPath = @"..\xml\config.xml";
    // string dir = @"..\bin\xml\";

    XElement productRoot;

    public DalProduct()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(path))
            throw new Exception("Product File upload problem");
        else
        {
            productRoot = XElement.Load(path);
        }
    }

    public int Add(Product product)
    {
        List<Product> ordrList = XmlTools.LoadListFromXMLSerializer<Product>(path);

        if (ordrList.Exists(x => x.ID == product.ID))
            throw new alreadyExistException("product is already exist");


        XElement Id = new XElement("ID", product.ID);
        XElement name = new XElement("Name", product.Name);
        XElement category = new XElement("Category", product.Category);
        XElement inStock = new XElement("InStock", product.inStock);
        XElement price = new XElement("Price", product.Price);
        XElement newProduct = new XElement("Product", Id, name, price, category, inStock);

        productRoot.Add(newProduct);
        productRoot.Save(path);

        ordrList.Add(product);
        XmlTools.SaveListToXMLSerializer(ordrList, path);

        return product.ID;
    }
    //  string path = @"..\xml\products.xml";
    //  string configPath = @"..\xml\config.xml";
    // // string dir = @"..\bin\xml\";

    ////  XElement productRoot;

    //  public DalProduct()
    //  {
    //      //LoadData();
    //  }

    //  private void LoadData()
    //  {
    //          if (!File.Exists(path))
    //              throw new Exception("product File upload problem");


    //      /* try
    //       {
    //           if (File.Exists(path))
    //               productRoot = XElement.Load(path);
    //           else
    //           {
    //               productRoot = new XElement("products");
    //               productRoot.Save(path);
    //           }
    //       }
    //       catch (Exception ex)
    //       {
    //           throw new Exception("product File upload problem" + ex.Message);
    //       }*/
    //  }

    //  public int Add(Product product)
    //  {
    //      List<Product> ordrList = XmlTools.LoadListFromXMLSerializer<Product>(path);

    //      if (ordrList.Exists(x => x.ID == product.ID))
    //          throw new AlredyExist("product");


    //      /* XElement Id = new XElement("ID", product.ID);
    //       XElement name = new XElement("Name", product.Name);
    //       XElement category = new XElement("Category", product.Category);
    //       XElement inStock = new XElement("InStock", product.InStock);
    //       XElement price = new XElement("Price", product.Price);
    //       XElement newProduct = new XElement("Product", Id, name, category, price, inStock);

    //       productRoot.Add(newProduct);
    //       productRoot.Save( path);*/

    //      ordrList.Add(product);
    //      XmlTools.SaveListToXMLSerializer(ordrList, path);

    //      return product.ID;
    //  }

    public void Delete(int id)
    {
        var newList = XmlTools.LoadListFromXMLSerializer<Product>(path);
        int index = newList.FindIndex(x => x.ID == id);
        if (index == -1)
            throw new alreadyExistException("product is already exist");

        newList.RemoveAt(index);
        XmlTools.SaveListToXMLSerializer(newList, path);
    }

    public Product GetByCondition(Func<Product?, bool>? cond)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Product>(path)
                where cond(item)
                select item).FirstOrDefault();
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? cond = null)
    {
        List<DO.Product?> prodList = XmlTools.LoadListFromXMLSerializer<DO.Product?>(path);

        if (cond == null)
            return prodList.AsEnumerable().OrderByDescending(p => p?.ID);

        return prodList.AsEnumerable<Product?>().Where(cond).OrderByDescending(p => p?.ID);

    }

    public Product Get(int id)
    {
        return (from item in XmlTools.LoadListFromXMLSerializer<Product>(path)
                where item.ID == id
                select item).FirstOrDefault();
    }

    public void Update(Product product)
    {
        List<Product> prodLst = XmlTools.LoadListFromXMLSerializer<Product>(path);

        if (!prodLst.Exists(x => x.ID == product.ID))
            throw new NotExistException("The product is't exist");

        int index = prodLst.FindIndex(x => x.ID == product.ID);
        prodLst[index] = product;
        XmlTools.SaveListToXMLSerializer(prodLst, path);
    }
}

