using FluentValidation;
using OnlaynBazar.WebApi.Models.Orders;

namespace OnlaynBazar.WebApi.Validators.Orders;

public class OrderUpdateModelValidator : AbstractValidator<OrderUpdateModel>
{
    public OrderUpdateModelValidator()
    {
        RuleFor(Order => Order.UserId)
          .NotNull()
          .WithMessage(Order => $"{nameof(Order.UserId)} is not specified");
    }
}
