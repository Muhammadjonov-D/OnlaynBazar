using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Entities.Products;

namespace OnlaynBazar.WebApi.Models.OrderItems;

public class OrderItemCreateModel
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}
