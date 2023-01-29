using BlApi;
using BO;
using Dal;

namespace BLImplementation
{
    internal class BLOrder : IOrder
    {
        DalApi.IDal? dal = DalApi.Factory.Get();

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
            IEnumerable<DO.OrderItem?> orderItems;

            try
            {
                orderItems = dal.OrderItem.GetAll().Where(x => x?.ID == id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            return new BO.Order()
            {
                Id = id,
                CustomerName = dOrder.CustomerName,
                CustomerEmail = dOrder.CustomerEmail,
                CustomerAddres = dOrder.CustomerAdress,
                OrderDate = dOrder.OrderDate,
                ShipDate = dOrder.OrderShipDate,
                DeliveryDate = dOrder.OrderDeliveryDate,
                status = OrderStatus.Delievered,
                TotalPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == id).Sum(x => x?.Price ?? 0),
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

        public Order GetOrder(int id)
        {

            DO.Order dOrder = new DO.Order();
            try
            {
                dOrder = dal.Order.Get(id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            IEnumerable<DO.OrderItem?> orderItems;

            try
            {
                orderItems = dal.OrderItem.GetAll().Where(x => x?.ID == id);
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
                            InStock = item.Amount,
                            Name = dal.Product.Get(item.ProductID).Name,
                            TotalPrice = item.Amount * item.Price
                        }
            };
        }

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

        public OrderTracking OrderTracking(int id)
        {
            DO.Order dOrder = new DO.Order();
            try
            {
                dOrder = dal.Order.Get(id);
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
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderDate, OrderStatus.Ordered),
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderShipDate, OrderStatus.Shipped),
                    new Tuple<DateTime?, OrderStatus>(dOrder.OrderDeliveryDate, OrderStatus.Delievered)
                }
            };
        }

        OrderStatus GetSatus(DO.Order? order)
        {
            return order?.OrderDeliveryDate != null ? OrderStatus.Delievered :
                order?.OrderShipDate != null ? OrderStatus.Shipped : OrderStatus.Ordered;
        }

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
            IEnumerable<DO.OrderItem?> orderItems;

            try
            {
                orderItems = dal.OrderItem.GetAll().Where(x => x?.ID == id);
            }
            catch (Exception ex)
            {
                throw new NotExistException(ex.Message);
            }

            return new BO.Order()
            {
                Id = id,
                CustomerName = dOrder.CustomerName,
                CustomerEmail = dOrder.CustomerEmail,
                CustomerAddres = dOrder.CustomerAdress,
                OrderDate = dOrder.OrderDate,
                ShipDate = dOrder.OrderShipDate,
                DeliveryDate = dOrder.OrderDeliveryDate,
                status = OrderStatus.Delievered,
                TotalPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == id).Sum(x => x?.Price ?? 0),
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

        public Order UpdateOrder()
        {
            throw new NotImplementedException("we did't do this function thus for bonus only\n");
        }
    }
}
