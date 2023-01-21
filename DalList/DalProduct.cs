
using DO;
using static Dal.DataSource;
namespace Dal;
using DalApi;
using System.Collections.Generic;
using System.Security.Cryptography;

internal class DalProduct:IProduct
{
    public  int Add(Product newProduct)   
    {

        productArr.Add( newProduct);
        return newProduct.ID;
    }

    public  Product Get(int id)
    {
        return productArr.Find(x=> x?.ID == id) ?? throw new Exception(); 
    }


    public  IEnumerable<Product?> GetAll(Func<Product?, bool>? func = null)
    {
        return func is null ? productArr.Select(x=>x) : productArr.Where(func);
    }

    public  void Delete(int id)
    {
        int index = productArr.FindIndex(x => x?.ID == id);
        if (index == -1)
            throw new Exception();
        productArr.RemoveAt(index);
     }


    public  void Update(Product product)
    {
        int index = productArr.FindIndex(x => x?.ID == product.ID);
        if (index == -1)
            throw new Exception();
        productArr[index] = product;
    }
}

