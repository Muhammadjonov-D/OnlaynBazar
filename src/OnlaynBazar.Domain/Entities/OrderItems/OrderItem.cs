using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Entities.Products;

namespace OnlaynBazar.Domain.Entities.OrderItems;

public class OrderItem : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}
