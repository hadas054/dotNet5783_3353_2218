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
        BO.Cart AddProduct(BO.Cart cert, int ID);

        /// <summary>
        /// update amount of product at cart by id and amount
        /// </summary>
        /// <param name="cert"></param>
        /// <param name="ID"></param>
        /// <param name="anount"></param>
        BO.Cart UpdateAmount(BO.Cart cert, int ID, int anount);

        /// <summary>
        /// check thr cart for new order
        /// </summary>
        /// <param name="cart"></param>
        void OrderConfirmation(BO.Cart cart);


    }
}
