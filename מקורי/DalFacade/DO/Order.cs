

namespace DO;

public struct Order
{
    public int OrderID { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerAdress { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? OrderShipDate { get; set; }
    public DateTime? OrderDeliveryDate { get; set; }

    public override string ToString() => $@"
ID               ={OrderID},
CustomerName     ={CustomerName},
CustomerEmail    ={CustomerEmail},
CustomerAdress   ={CustomerAdress},
OrderDate        ={OrderDate},
ShipDate         ={OrderShipDate},
DeliveryDate     ={OrderDeliveryDate}
";    
}
