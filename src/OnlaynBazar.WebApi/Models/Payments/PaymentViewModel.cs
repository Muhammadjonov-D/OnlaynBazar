using OnlaynBazar.Domain.Enums;
using OnlaynBazar.WebApi.Models.Orders;

namespace OnlaynBazar.WebApi.Models.Payments;

public class PaymentViewModel
{
    public long Id { get; set; }
    public OrderViewModel Order { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
}
