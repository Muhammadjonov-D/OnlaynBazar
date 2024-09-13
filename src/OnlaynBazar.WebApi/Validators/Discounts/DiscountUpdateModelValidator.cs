using FluentValidation;
using OnlaynBazar.WebApi.Models.Discounts;

namespace OnlaynBazar.WebApi.Validators.Discounts;

public class DiscountUpdateModelValidator : AbstractValidator<DiscountUpdateModel>
{
    public DiscountUpdateModelValidator()
    {
        RuleFor(disocunt => disocunt.Code)
    .NotNull()
    .WithMessage(discount => $"{nameof(discount.Code)} is not specified");
    }
}
