using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.Domain.Entities.Payments;

public class Payment : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set;}
    public DateTime PaymentDate { get; set; }
}
