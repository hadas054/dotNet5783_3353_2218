
using DO;

namespace Dal;

public class DalProduct
{
    public static int Add(Product newProduct)   //אילה אמרה שלפי הוראות המתודה בקובץ הזה לא צריכ ה להחזיר ערך
    {
        for(int i=0;i< DataSource.countOfProductArry;i++)
        {
            if (DataSource.productArr[i].ID == newProduct.ID)
                throw new Exception("the product is exist");
        }
        DataSource.productArr[DataSource.countOfProductArry++]=newProduct;  //אולי לעשות את הפלוס פלוס בנפרד
        return newProduct.ID;
    }

    public static Product Get(int id)
    {

        for (int i = 0; i <= DataSource.productArr.Length; i++)
        {
            if (DataSource.productArr[i].ID == id)
                return DataSource.productArr[i];
        }
        throw new Exception("the product does not exist");

    }


    public static Product[] allProducts()
    {
        Product[] Arr = new Product[DataSource.countOfProductArry];
        for (int i = 0; i < DataSource.countOfProductArry; i++)
            Arr[i] = DataSource.productArr[i]; 
        return Arr;
    }

    public static void Delete(int id)
    {
        bool flag = false;

        for (int i = 0; i <= DataSource.productArr.Length; i++)
        {
            if (DataSource.productArr[i].ID == id)
            {
                DataSource.productArr[i] = DataSource.productArr[DataSource.countOfProductArry];
                DataSource.countOfProductArry--;
                flag = true;
            }
        }
        if (flag == false)
            throw new Exception("cannot delete an Product,it is not exists");
    }


    public static void Update(Product product)
    {
        // DataSource.OrderItemArr.Length;
        bool x = false;
        for (int i = 0; i <= DataSource.productArr.Length; i++)
        {
            if (DataSource.productArr[i].ID == product.ID)
            {
                x = true;
                DataSource.productArr[i] = product;
            }
        }
        if (x == false)
            throw new Exception("cannot update an product,it is not exists");

    }
}

