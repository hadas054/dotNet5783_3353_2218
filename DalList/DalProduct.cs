
using DO;
using static Dal.DataSource;
namespace Dal;
using DalApi;
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


    public  IEnumerable<Product?> GetAll()
    {
        //List<Product?> list = productArr.ToList();
        //return list;

        return from Product? product in productArr
               select product;

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

