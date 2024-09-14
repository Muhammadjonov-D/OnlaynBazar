using FluentValidation;
using OnlaynBazar.WebApi.Models.Categories;

namespace OnlaynBazar.WebApi.Validators.Categories;

public class CategoryCreateModelValidator : AbstractValidator<CategoryCreateModel>
{
    public CategoryCreateModelValidator()
    {
        RuleFor(category => category.Name)
            .NotNull()
            .WithMessage(category => $"{nameof(category.Name)} is not specified");
    }
}
