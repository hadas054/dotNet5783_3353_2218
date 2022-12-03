using BlApi;
using BO;
using Dal;

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
            throw new NotImplementedException();
        }

        public Cart UpdateAmount(Cart cert, int ID, int anount)// כמו פונקצייה קודמת רק שלא מוסיפים 1 אלא כמה שביקשו וצריכים לשים לב אם הוסיפו  0  מוצרים אז צריך למחוק את האורדר אייטם הנוכחי

        {
            throw new NotImplementedException();
        }
    }
}
