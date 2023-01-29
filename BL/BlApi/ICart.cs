using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ICart 
    {
        /// <summary>
        /// Add new product to the cart
        /// </summary>
        /// <param name="cert"></param>
        /// <param name="ID"></param>
        BO.Cart AddProduct(BO.Cart cart, int ID);

        /// <summary>
        /// update amount of product at cart by id and amount
        /// </summary>
        /// <param name="cert"></param>
        /// <param name="ID"></param>
        /// <param name="anount"></param>
        BO.Cart UpdateAmount(BO.Cart cart, int ID, int amount);

        /// <summary>
        /// check thr cart for new order
        /// </summary>
        /// <param name="cart"></param>
        BO.Cart OrderConfirmation(BO.Cart cart);


    }
}
