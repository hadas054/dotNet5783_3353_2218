
using DO;

namespace Dal;

public class DalProduct
{
    public int Add(Product newProduct)
    {
        for(int i=0;i<=50;i++)
        {
            if (DataSource.ProductArr[i].ID == newProduct.ID)
                throw new Exception("the product is exist");
        }
        DataSource.ProductArr[DataSource.CountOfProductArry++]=newProduct;
        return newProduct.ID;
    }
}
