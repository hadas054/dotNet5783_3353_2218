using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IOrder
    {
        /// <summary>
        /// return order list for manager
        /// </summary>
        /// <returns></returns>
        IEnumerable<BO.OrderForList> GetOrders(Func <BO.OrderForList, bool > func = null);

        /// <summary>
        /// return order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BO.Order GetOrder(int id);

        /// <summary>
        /// Updates that the order has been sent
        /// </summary>
        /// <param name="id"></param>
        BO.Order SentOrder(int id);

        /// <summary>
        /// Updates the database that the order has been delivered
        /// </summary>
        /// <param name="id"></param>
        BO.Order DeliveredOrder(int id);

        /// <summary>
        /// return list of order traking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderTracking OrderTracking(int id);

        /// <summary>
        /// updateorder for manager
        /// </summary>
        /// <returns></returns>
        BO.Order UpdateOrder();

        public BO.Order GetTheOldOne();
    }
}
