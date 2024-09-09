using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }  
    public decimal TotalAmount { get; set; }
    public decimal Price { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string WarehouseAddress { get; set; }
    public long OrderItem {  get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
