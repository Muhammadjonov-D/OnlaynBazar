using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.Domain.Entities.OrderManagements;

public class OrderManagement : Auditable
{
    public long OrderId { get; set; }   
    public Order Order { get; set; }
    public OrderStatus Status { get; set; }
}
