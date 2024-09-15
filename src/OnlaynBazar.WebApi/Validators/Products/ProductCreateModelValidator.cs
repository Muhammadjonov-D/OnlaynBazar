using FluentValidation;
using OnlaynBazar.WebApi.Models.Products;

namespace OnlaynBazar.WebApi.Validators.Products;

public class ProductCreateModelValidator : AbstractValidator<ProductCreateModel>
{
    public ProductCreateModelValidator()
    {
        RuleFor(product => product.Name)
            .NotNull()
            .WithMessage(product => $"{nameof(product.Name)} is not specified");

        RuleFor(product => product.CategoryId)
            .NotNull()
            .WithMessage(product => $"{nameof(product.CategoryId)} is not specified");

        RuleFor(product => product.DiscountId)
            .NotNull()
            .WithMessage(product => $"{nameof(product.DiscountId)} is not specified");
    }
}
