using FluentValidation;
using OnlaynBazar.WebApi.Models.OrderItems;

namespace OnlaynBazar.WebApi.Validators.OrderItems;

public class OrderItemCreateModelValidator : AbstractValidator<OrderItemCreateModel>
{
    public OrderItemCreateModelValidator()
    {
        RuleFor(orderItem => orderItem.OrderId)
            .NotNull()
            .WithMessage(orderItem => $"{nameof(orderItem.OrderId)} is not specified");

        RuleFor(orderItem => orderItem.Quantity)
           .NotNull()
           .WithMessage(orderItem => $"{nameof(orderItem.Quantity)} is not specified");

        RuleFor(orderItem => orderItem.ProductId)
          .NotNull()
          .WithMessage(orderItem => $"{nameof(orderItem.ProductId)} is not specified");
    }
}
