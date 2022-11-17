
using DO;

namespace Dal;

public class DalProduct
{
    public static void Add(Product newProduct)   //אילה אמרה שלפי הוראות המתודה בקובץ הזה לא צריכ ה להחזיר ערך ואיילה מאוד מאוד טועה
    {
        newProduct.ID = DataSource.rand.Next(100000, 1000000);
        bool check = true;
        while (check)
        {  
            check = false;  
            for (int i = 0; i < DataSource.productArr.Length; i++)
            {
                if (DataSource.productArr[i].ID == newProduct.ID)
                {
                    newProduct.ID = DataSource.rand.Next(100000, 1000000);
                    check = true;
                    break;
                }
            }
        }
        DataSource.productArr[DataSource._nextEmptyProduct++] = newProduct; 
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
        Product[] Arr = new Product[DataSource._nextEmptyProduct];
        for (int i = 0; i < DataSource._nextEmptyProduct; i++)
            Arr[i] = DataSource.productArr[i];
        return Arr;
    }

    public static void Delete(int id)
    {
        for (int i = 0; i < DataSource._nextEmptyProduct; i++)
        {
            if (DataSource.productArr[i].ID == id)
            {
              for(int j = i; j < DataSource._nextEmptyProduct; j++)
                {
                    DataSource.productArr[i] = DataSource.productArr[i + 1];
                }
                DataSource._nextEmptyProduct--;
                return;
            }
        }
            throw new Exception("cannot delete an Product,it is not exists");
    }


    public static void Update(Product product)
    {
        for (int i = 0; i <= DataSource._nextEmptyProduct; i++)
        {
            if (DataSource.productArr[i].ID == product.ID)
            {
                DataSource.productArr[i] = product;
                return;
            }
        }
            throw new Exception("cannot update an product,it is not exists");

    }
}

