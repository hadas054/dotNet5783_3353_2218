using BO;
using Dal;
using System.Security.Cryptography;

namespace BLImplementation
{
    internal class BlCart : BlApi.ICart
    {
        DalApi.IDal? dal = DalApi.Factory.Get();

        public Cart AddProduct(Cart cart, int ID)
        {
            if (cart.Items == null)
                cart.Items = new List<BO.OrderItem>();

            int index = cart.Items.FindIndex(x => x.ProductId == ID);

            DO.Product? product;
            try
            {
                product = dal.Product.Get(ID);
                if (product?.inStock < 1)
                    throw new ConfirmException("the product no avaliable");
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            if (index != -1)
            {
                cart.Items[index].Amount++;
                cart.Items[index].TotalPrice += product?.Price ?? 0;
                cart.TotalPrice += product?.Price ?? 0;
                return cart;
            }

            cart.Items.Add(new BO.OrderItem()
            {
                Name = product?.Name,
                Amount = 1,
                Price = product.Value.Price,
                ProductId = product.Value.ID,
                TotalPrice = product.Value.Price
            });

            return cart;
        }

        public void OrderConfirmation(Cart cart)
        {

            var products = dal.Product.GetAll();

            foreach (var item in cart.Items)
            {
                DO.Product p = new DO.Product();
                try
                {
                    if (!products.Any(pro => pro?.ID == item.ProductId))
                        p = dal.Product.Get(item.ProductId);
                }
                catch (Exception ex)
                {
                    throw new NotExistException("cart confirmation" + ex.Message + "\n");
                }

                if (item.Amount < 0 || item.Price < 0)
                    throw new ConfirmException("negativ amount\n");

                if (p.inStock < item.Amount)
                    throw new ConfirmException("the product no avaliable\n");

                if ((cart.CustomerName == "") || (cart.CustomerAddress == ""))
                    throw new ConfirmException("Invalid name or address\n");

                if (!cart.CustomerEmail.Contains("@gmail.com"))
                    throw new ConfirmException("Invalid email address\n");

                p.inStock -= item.Amount;
                dal.Product.Update(p);

            }

            DO.Order order = new DO.Order()
            {
                CustomerName = cart.CustomerName,
                CustomerEmail = cart.CustomerEmail,
                CustomerAdress = cart.CustomerAddress,
                OrderDate = DateTime.Now,
                OrderDeliveryDate = null,
                OrderShipDate = null
            };

            int idOrder;
            try
            {
                idOrder = dal.Order.Add(order);
            }
            catch (Exception ex)
            {
                throw new alreadyExistException(ex.Message);
            }


            foreach (var item in cart.Items)
            {
                DO.OrderItem orderItem = new DO.OrderItem()
                {
                    ProductID = item.ProductId,
                    OrderID = idOrder,
                    Price = item.Price,
                    Amount = item.Amount
                };
                try
                {
                    dal.OrderItem.Add(orderItem);
                }
                catch (Exception ex)
                {
                    throw new alreadyExistException(ex.Message);
                }

            }
        }

        public Cart UpdateAmount(Cart cart, int ID, int amount)
        {
            int index = cart.Items.FindIndex(x => x.ProductId == ID);

            DO.Product product = new DO.Product();

            try
            {
                product = dal.Product.Get(ID);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            if (index == -1)
                throw new NotExistException("the product is't in cart");

            if (amount != 0)
            {
                cart.Items[index].Amount = amount;
                cart.Items[index].TotalPrice = cart.Items.Sum(x => x.Amount * x.Price);
                cart.TotalPrice = cart.Items.Sum(x => x.TotalPrice);
            }

            if (amount == 0)
            {
                cart.Items.RemoveAt(index);
                cart.TotalPrice = cart.Items.Sum(x => x.TotalPrice);
            }

            return cart;
        }
    }


}
