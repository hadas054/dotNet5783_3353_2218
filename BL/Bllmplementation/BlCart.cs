using BlApi;
using BO;
using Dal;
using System.Security.Cryptography;

namespace BLImplementation
{
    internal class BlCart : ICart
    {
        DalApi.IDal dal = new Dal.DalList();

        public Cart AddProduct(Cart cart, int ID)
        {
            int index = cart.Items.FindIndex(x => x.ProductId == ID);

            DO.Product? product = dal.Product.Get(ID);
            if (product?.inStock < 1)
                throw new Exception();

            if (index != -1)
            {
                cart.Items[index].Amount++;
                cart.Items[index].TotalPrice += product.Value.Price;
                cart.TotalPrice += product.Value.Price;
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

        public void OrderConfirmation(Cart cart)// נעשה יחד אם תסתבכי
        {

            var products = dal.Product.GetAll();
            foreach (var item in cart.Items)
            {
                if (products.Any(pro => pro?.ID == item.ProductId && pro?.Name == item.Name) == false)
                    throw new Exception();
                DO.Product? p = dal.Product.Get(item.ProductId);
                if (item.Amount < 0 || item.Price < 0)
                    throw new Exception();
                if (p?.inStock - item.Amount < 0)
                    throw new Exception(); 
                if ((cart.CustomerName == " ") || (cart.CustomerAddress == " "))
                    throw new Exception();
                if (!cart.CustomerEmail.Contains("@gmail.com"))
                    throw new Exception();

            }

            DO.Order order = new DO.Order()
            {
                CustomerName = cart.CustomerName,
                CustomerEmail = cart.CustomerEmail,
                CustomerAdress = cart.CustomerAddress,
                OrderDate = DateTime.Now,
                OrderDeliveryDate = new DateTime(),//null
                OrderShipDate = new DateTime(),   //null
            };

               int idOrder = dal.Order.Add(order);
            
           
            foreach (var item in cart.Items)
            {
                DO.OrderItem orderItem = new DO.OrderItem()
                {
                    ProductID = item.ProductId,
                    OrderID = idOrder,
                    Price = item.Price,
                    Amount = item.Amount,
                  
                };
                dal.OrderItem.Add(orderItem);
            }

            /* var orderItems=from OrderItem item in cart.Items
              select new DO.OrderItem()
               {
               ProductID = item.ProductId,
               OrderID = idOrder,
               Price = item.Price,
               Amount = item.Amount,
              };*/



            //לעדכן מלאי


        }

        public Cart UpdateAmount(Cart cart, int ID, int amount)// כמו פונקצייה קודמת רק שלא מוסיפים 1 אלא כמה שביקשו וצריכים לשים לב אם הוסיפו  0  מוצרים אז צריך למחוק את האורדר אייטם הנוכחי
            //מביאים לי את הכמות להוסיף?או כמות חדשה?
        {
            int index=cart.Items.FindIndex(x => x.ProductId == ID);
            DO.Product?product=dal.Product.Get(ID);
            if (index == -1)
                throw new Exception();
            if(cart.Items[index].Amount<amount)
            {
                cart.Items[index].Amount+=amount;
                cart.Items[index].TotalPrice+=(cart.Items[index].Price*amount);
                cart.TotalPrice+= (cart.Items[index].Price * amount);
            }
            if (cart.Items[index].Amount == amount)
            {
                cart.Items.Remove(new BO.OrderItem()
                {
                    Name = product?.Name,
                    Amount = 0,
                    Price = product.Value.Price,
                    ProductId = product.Value.ID,
                    TotalPrice = product.Value.Price
                });

            }

                if (cart.Items[index].Amount>amount)
            {
                cart.Items[index].Amount -= amount;
                cart.Items[index].TotalPrice-= (cart.Items[index].Price * amount);
                cart.TotalPrice-= (cart.Items[index].Price * amount);
            }

            return cart;
        }
    }


}
