using OnlaynBazar.WebApi.Models.Orders;
using OnlaynBazar.WebApi.Models.Products;

namespace OnlaynBazar.WebApi.Models.OrderItems;

public class OrderItemViewModel
{
    public OrderViewModel OrderId { get; set; }
    public ProductViewModel ProductId { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}
