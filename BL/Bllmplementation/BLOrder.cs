using BlApi;
using BO;
using Dal;

namespace BLImplementation
{
    internal class BLOrder : IOrder
    {
        DalApi.IDal dal = new DalList();
        public Order DeliveredOrder(int id)
        {
            if (id < 0)
                throw new Exception();

            DO.Order dOrder = dal.Order.Get(id);

            if (dOrder.OrderShipDate == null)//בידקה אם ההזמנה נשלחה בכלל
                throw new Exception();

            if (dOrder is DO.Order order)
            {
                order.OrderDeliveryDate = DateTime.Now;
                dal.Order.Update(order);
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
                TotalPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == id).Sum(x => x?.Price ?? 0)
            };
        }

        public Order GetOrder(int id)
        {
            DO.Order dOrder = dal.Order.Get(id);

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
                TotalPrice = dal.OrderItem.GetAll().Where(x => x.Value.OrderID == id).Sum(x => x?.Price ?? 0),

                Items = from DO.OrderItem item in dal.OrderItem.GetAll().Select(x => x?.OrderID == id)
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

        public IEnumerable<OrderForList> GetOrders()
        {
            return from DO.Order item in dal.Order.GetAll()
                   select new BO.OrderForList()
                   {
                       Id = item.OrderID,
                       CustomerName = item.CustomerName,
                       Status = GetSatus(item),
                       AmountOfItems = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.OrderID).Sum(x => x?.Amount ?? 0),
                       TotaiPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.OrderID).Sum(x => x?.Price ?? 0 )
                   };
        }

        public OrderTracking OrderTracking(int id)
        {
            DO.Order dOrder = dal.Order.Get(id);
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
            return order?.OrderShipDate != null ? OrderStatus.Delievered :
                order?.OrderShipDate != null ? OrderStatus.Shipped : OrderStatus.Ordered;
        }



        public Order SentOrder(int id)
        {
            if (id < 0)
                throw new Exception();

            DO.Order dOrder = dal.Order.Get(id);

            if (dOrder is DO.Order order)
            {
                order.OrderShipDate = DateTime.Now;
                dal.Order.Update(order);
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
                TotalPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == id).Sum(x => x?.Price ?? 0)
            };
        }

        public Order UpdateOrder()
        {
            
        }
    }
}
