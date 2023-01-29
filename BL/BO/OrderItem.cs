using DO;

namespace BO;

public class OrderItem
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int InStock { get; set; }
    public double TotalPrice { get; set; }
    public override string ToString()
    {
        return this.ToStringProperty();
    }
}
