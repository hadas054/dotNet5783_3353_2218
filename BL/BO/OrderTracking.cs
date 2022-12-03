using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class OrderTracking
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public List<Tuple<DateTime?, OrderStatus>>? Tracking { get; set; }


}
