namespace OnlaynBazar.WebApi.Models.OrderItems;

public class OrderItemUpdateModel
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}
