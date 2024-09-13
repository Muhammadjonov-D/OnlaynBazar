using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Enums;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.Models.Orders;

public class OrderViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Price { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string WarehouseAddress { get; set; }
    public long OrderItem { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
