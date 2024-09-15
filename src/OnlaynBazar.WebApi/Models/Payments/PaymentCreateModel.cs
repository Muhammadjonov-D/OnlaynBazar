using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.WebApi.Models.Payments;

public class PaymentCreateModel
{
    public long OrderId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
}
