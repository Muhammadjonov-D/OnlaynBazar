using FluentValidation;
using OnlaynBazar.WebApi.Models.Orders;

namespace OnlaynBazar.WebApi.Validators.Orders;

public class OrderCreateModelValidator : AbstractValidator<OrderCreateModel>
{
    public OrderCreateModelValidator()
    {
        RuleFor(Order => Order.UserId)
          .NotNull()
          .WithMessage(Order => $"{nameof(Order.UserId)} is not specified");
    }
}
