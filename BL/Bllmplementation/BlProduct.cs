﻿using BlApi;
using BO;

namespace BLImplementation
{
    internal class BlProduct : IProduct
    {
        DalApi.IDal dal = new Dal.DalList();
        public void AddProduct(BO.Product product)
        {
            if (product.Id < 0 || product.Name == "" || product.Price <= 0 || product.Instock < 0)
                throw new ArgumentException();
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
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            if (dal.OrderItem.GetAll().Select(x => x?.ID == id).Any())
                throw new Exception();

            dal.Product.Delete(id);
        }

        public BO.ProductItem GetProductC(int id)
        {
            DO.Product dProduct = dal.Product.Get(id);

            return new BO.ProductItem()
            {
                Id = dProduct.ID,
                Name = dProduct.Name,
                Price = dProduct.Price,
                Category = (BO.Category)dProduct.Category,
                Instock = dProduct.inStock >0 ? true : false
            };
        }

        public Product GetProductM(int id)
        {

            if (id < 0)
                throw new Exception();
            
                DO.Product dProduct = dal.Product.Get(id);

                return (new BO.Product()
                {

                    Id = dProduct.ID,
                    Name = dProduct.Name,
                    Price = dProduct.Price,
                    Category = (BO.Category)dProduct.Category,
                    Instock = dProduct.inStock

                });
        }

        public IEnumerable<ProductForList> GetProducts()
        {
            return from DO.Product dProduct in dal.Product.GetAll()
                   select new BO.ProductForList()
                   {
                       Id = dProduct.ID,
                       Name = dProduct.Name,
                       Category = (BO.Category)dProduct.Category,
                       Price = dProduct.Price
                   };
        }

        public void Update(Product product)
        {
            if (product.Id < 0 || product.Name == "" || product.Price <= 0 || product.Instock < 0)
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
                throw new Exception();
            }
        }
    }
}
