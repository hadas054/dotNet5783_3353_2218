using BlApi;
using BO;
using System.Runtime.CompilerServices;

namespace BLImplementation
{
    internal class BlProduct : IProduct
    {
        DalApi.IDal? dal = DalApi.Factory.Get();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddProduct(BO.Product product)
        {
            if (product.Id < 0 || product.Name == "" || product.Price <= 0 || product.Instock < 0)
                throw new Exception("the info is Error\n");

            try
            {
                dal.Product.Add(new DO.Product()
                {
                    ID = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Category = (DO.Category)product.Category,
                    inStock = product.Instock
                });
            }
            catch (Exception ex)
            {
                throw new alreadyExistException(ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Delete(int id)
        {
            try
            {
                dal.OrderItem.GetAll().Select(x => x?.ID == id).Any();
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            dal.Product.Delete(id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public BO.ProductItem GetProductC(int id)
        {
            DO.Product dProduct = dal.Product.Get(id);

            return new BO.ProductItem()
            {
                Id = dProduct.ID,
                Name = dProduct.Name,
                Price = dProduct.Price,
                Category = (BO.Category)dProduct.Category,
                InStock = dProduct.inStock > 0 
            };
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Product GetProductM(int id)
        {

            if (id < 0)
                throw new Exception();

            DO.Product dProduct = new DO.Product();
            try
            {
                dProduct = dal.Product.Get(id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            return (new BO.Product()
            {
                Id = dProduct.ID,
                Name = dProduct.Name,
                Price = dProduct.Price,
                Category = (BO.Category)dProduct.Category,
                Instock = dProduct.inStock
            });
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IEnumerable<ProductForList?> GetProductsList(Func<ProductForList, bool>? func = null)
        {
            try
            {
                IEnumerable<ProductForList?> products = from DO.Product dProduct in dal.Product.GetAll()
                                                        select new BO.ProductForList()
                                                        {
                                                            Id = dProduct.ID,
                                                            Name = dProduct.Name,
                                                            Category = (BO.Category)dProduct.Category,
                                                            Price = dProduct.Price,
                                                            Amount = dProduct.inStock                                                             
                                                        };

                return func == null ? products : products.Where(func!);
            }
            catch(Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IEnumerable<ProductItem?> GetProductsItem(Cart cart,Func<ProductItem, bool>? func = null)
        {
            try
            {
                IEnumerable<ProductItem?> products = from DO.Product dProduct in dal.Product.GetAll()
                                                        select new BO.ProductItem()
                                                        {
                                                            Id = dProduct.ID,
                                                            Name = dProduct.Name,
                                                            Category = (BO.Category)dProduct.Category,
                                                            Price = dProduct.Price,
                                                            InStock = dProduct.inStock>0,
                                                            AmountInCart = (from order in cart.Items
                                                                            where dProduct.ID == order.ProductId
                                                                            select order.Amount).FirstOrDefault()
                                                           
                                                        };

                return func == null ? products : products.Where(func);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Update(Product product)
        {
            
            if (product == null||product.Id < 0 || product.Name == "" || product.Price <= 0 || product.Instock < 0)
                throw new ArgumentException();

            try
            {
                dal.Product.Update(new DO.Product()
                {
                    ID = product.Id,
                    Name = product.Name,
                    Category = (DO.Category)product.Category,
                    inStock = product.Instock,
                    Price = product.Price
                });

            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
        }
    }
}
