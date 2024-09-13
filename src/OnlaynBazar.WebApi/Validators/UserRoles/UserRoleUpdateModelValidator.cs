using FluentValidation;
using OnlaynBazar.WebApi.Models.UserRoles;

namespace OnlaynBazar.WebApi.Validators.UserRoles;

public class UserRoleUpdateModelValidator : AbstractValidator<UserRoleUpdateModel>
{
    public UserRoleUpdateModelValidator()
    {
        RuleFor(userRole => userRole.Name)
            .NotNull()
            .WithMessage(userRole => $"{nameof(userRole.Name)} is not specified");
    }
}