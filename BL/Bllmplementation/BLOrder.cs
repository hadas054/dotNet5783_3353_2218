using BlApi;
using BO;
using Dal;
using System.Runtime.CompilerServices;

namespace BLImplementation
{
    internal class BLOrder : IOrder
    {
        DalApi.IDal? dal = DalApi.Factory.Get();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Order DeliveredOrder(int id)
        {
            if (id < 0)
                throw new Exception("negativ id\n");

            DO.Order dOrder = new DO.Order();
            try
            {
                dOrder = dal.Order.Get(id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            if (dOrder.OrderShipDate == null)//בידקה אם ההזמנה נשלחה בכלל
                throw new Exception("the order is not\n");

            if (dOrder is DO.Order order)
            {
                order.OrderDeliveryDate = DateTime.Now;
                dal.Order.Update(order);
            }
            return GetOrder(id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Order GetOrder(int id)
        {

            DO.Order dOrder = new DO.Order();
            try
            {
                dOrder = dal!.Order.Get(id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            IEnumerable<DO.OrderItem?> orderItems;

            try
            {
                orderItems = dal.OrderItem.GetAll().Where(x => x.Value.OrderID == id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }


            return new BO.Order()
            {
                Id = dOrder.OrderID,
                CustomerName = dOrder.CustomerName,
                CustomerEmail = dOrder.CustomerEmail,
                CustomerAddres = dOrder.CustomerAdress,
                OrderDate = dOrder.OrderDate,
                ShipDate = dOrder.OrderShipDate,
                DeliveryDate = dOrder.OrderDeliveryDate,
                status = GetSatus(dOrder),
                TotalPrice = orderItems.Where(x => x?.OrderID == id).Sum(x => x?.Price ?? 0),

                Items = from DO.OrderItem item in orderItems
                        select new BO.OrderItem()
                        {
                            ProductId = item.ProductID,
                            Price = item.Price,
                            Amount = item.Amount,
                            Name = dal.Product.Get(item.ProductID).Name,
                            TotalPrice = item.Amount * item.Price
                        }
            };
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IEnumerable<OrderForList> GetOrders(Func<BO.OrderForList, bool> func = null)
        {
            try
            {
                IEnumerable<OrderForList> list = from DO.Order item in dal.Order.GetAll()
                                                 select new BO.OrderForList()
                                                 {
                                                     Id = item.OrderID,
                                                     CustomerName = item.CustomerName,
                                                     Status = GetSatus(item),
                                                     AmountOfItems = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.OrderID).Sum(x => x?.Amount ?? 0),
                                                     TotaiPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.OrderID).Sum(x => x?.Price ?? 0)
                                                 };
                return func is null ? list : list.Where(func);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public OrderTracking OrderTracking(int id)
        {
            DO.Order dOrder = new DO.Order();
            try
            {
                dOrder = dal!.Order.Get(id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
            return new OrderTracking()
            {
                Id = id,
                Status = GetSatus(dOrder),
                Tracking = new List<Tuple<DateTime?, OrderStatus>>
                {
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderDate, OrderStatus.Paid),
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderShipDate, OrderStatus.Shipped),
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderDeliveryDate, OrderStatus.Delievered)
                }
            };
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        OrderStatus GetSatus(DO.Order? order)
        {
            return order?.OrderDeliveryDate != null ? OrderStatus.Delievered :
                order?.OrderShipDate != null ? OrderStatus.Shipped : OrderStatus.Paid;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Order SentOrder(int id)
        {
            if (id < 0)
                throw new Exception();

            DO.Order dOrder = dal.Order.Get(id);

            if (dOrder.OrderShipDate != null)
                throw new Exception();

            if (dOrder is DO.Order order)
            {
                order.OrderShipDate = DateTime.Now;
                dal.Order.Update(order);
            }

            return GetOrder(id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public BO.Order GetTheOldOne()
        {
            IEnumerable<IGrouping<int?, DO.OrderItem?>> orderItems = from item in dal.OrderItem.GetAll()
                                                                     group item by item?.OrderID into g
                                                                     select g;

            IEnumerable<BO.Order> orders = from order in dal.Order.GetAll()
                                           select new BO.Order
                                           {
                                               Id = order?.OrderID ?? throw new BO.NotExistException("the order id is't found "),
                                               CustomerName = order?.CustomerName,
                                               CustomerEmail = order?.CustomerEmail,
                                               CustomerAddres = order?.CustomerAdress,
                                               OrderDate = order?.OrderDate,
                                               ShipDate = order?.OrderShipDate,
                                               DeliveryDate = order?.OrderDeliveryDate,
                                               status = GetStatus(order),
                                               Items = GetOrderItemList(order?.OrderID ?? throw new BO.NotExistException("the order id is't found ")).ToList()!,
                                               TotalPrice = (double)(from item in orderItems
                                                                     where item.Key == order?.OrderID
                                                                     select item).Sum(x => x.Sum(x => x?.Price))!
                                           }; ;
            return orders.OrderBy(x => x.status).ThenBy(x => x.OrderDate).First();

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Order UpdateOrder()
        {
            throw new NotImplementedException("we did't do this function thus for bonus only\n");
        }

        private OrderStatus GetStatus(DO.Order? dOrder)
        {
            return dOrder?.OrderDeliveryDate != null ? OrderStatus.Delievered :
                dOrder?.OrderShipDate != null ? OrderStatus.Shipped : OrderStatus.Paid;
        }

        private IEnumerable<OrderItem> GetOrderItemList(int id)
        {
            try
            {
                return from DO.OrderItem item in dal.OrderItem.GetAll(x => x?.OrderID == id)
                       select new BO.OrderItem()
                       {
                           ProductId = item.ProductID,
                           Name = dal.Product.Get(item.ProductID).Name,
                           Amount = item.Amount,
                           Price = item.Price / item.Amount,
                           TotalPrice = item.Price
                       };
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }
        }

    }
}
