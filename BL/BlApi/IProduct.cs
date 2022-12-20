
using BO;

namespace BlApi;

public interface IProduct
{

    /// <summary>
    /// return all product
    /// </summary>
    /// <returns></returns>
    IEnumerable<BO.ProductForList> GetProducts(Func<ProductForList, bool>? func = null);

    /// <summary>
    /// return product by ID for manager
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    BO.Product GetProductM (int id);

    /// <summary>
    /// return product by ID for manager
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    BO.ProductItem GetProductC (int id); 
    
    /// <summary>
    /// Add new product to DB
    /// </summary>
    /// <param name="product"></param>
    void AddProduct (BO.Product product);

    /// <summary>
    /// delete product from DB
    /// </summary>
    /// <param name="product"></param>
    void Delete (int id);

    /// <summary>
    /// update product properties
    /// </summary>
    /// <param name="product"></param>
    void Update(BO.Product product);
}
