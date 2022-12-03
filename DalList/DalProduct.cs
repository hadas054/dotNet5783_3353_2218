
using DO;
using static Dal.DataSource;
namespace Dal;
using DalApi;

internal class DalProduct:IProduct
{
    public  int Add(Product newProduct)   
    {
        bool check = true;

        while (check)
        {
            newProduct.ID = DataSource.rand.Next(100000, 1000000);

            if (!productArr.Exists(x => x?.ID == newProduct.ID))
                check = false;
        }
        productArr.Add(newProduct);
        return newProduct.ID;
    }

    public  Product? Get(int id)
    {
        return productArr.Find(x=> x?.ID == id); 
    }


    public  IEnumerable<Product?> GetAll()
    {
        List<Product?> list = productArr.ToList();
        return list;
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

