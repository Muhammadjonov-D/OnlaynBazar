using FluentValidation;
using OnlaynBazar.WebApi.Models.Payments;

namespace OnlaynBazar.WebApi.Validators.Payments;

public class PaymentCreateModelValidator : AbstractValidator<PaymentCreateModel>
{
    public PaymentCreateModelValidator()
    {
        RuleFor(payment => payment.OrderId)
            .NotNull()
            .WithMessage(payment => $"{nameof(payment.OrderId)} is not specified");
    }
}
