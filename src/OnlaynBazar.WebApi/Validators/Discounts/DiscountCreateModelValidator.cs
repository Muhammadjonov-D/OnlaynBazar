using FluentValidation;
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.Service.Helpers;
using OnlaynBazar.WebApi.Models.Discounts;

namespace OnlaynBazar.WebApi.Validators.Discounts;

public class DiscountCreateModelValidator : AbstractValidator<DiscountCreateModel>
{
    public DiscountCreateModelValidator()
    {
        RuleFor(disocunt => disocunt.Code)
    .NotNull()
    .WithMessage(discount => $"{nameof(discount.Code)} is not specified");
    }
}
