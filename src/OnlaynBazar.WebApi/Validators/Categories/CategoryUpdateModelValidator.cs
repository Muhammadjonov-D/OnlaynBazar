using FluentValidation;
using OnlaynBazar.WebApi.Models.Categories;

namespace OnlaynBazar.WebApi.Validators.Categories;

public class CategoryUpdateModelValidator : AbstractValidator<CategoryUpdateModel>
{
    public CategoryUpdateModelValidator()
    {
        RuleFor(Category => Category.Name)
            .NotNull()
            .WithMessage(Category => $"{nameof(Category.Name)} is not specified");
    }
}
