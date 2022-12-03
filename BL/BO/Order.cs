using DO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerAddres { get; set; }
    public OrderStatus status { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public IEnumerable<OrderItem>? Items { get; set; }
    public double TotalPrice { get; set; }
    public override string ToString()
    {
        return this.ToStringProperty();
    }
}
