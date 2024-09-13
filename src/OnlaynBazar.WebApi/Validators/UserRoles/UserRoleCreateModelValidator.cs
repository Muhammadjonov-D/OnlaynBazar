using FluentValidation;
using OnlaynBazar.WebApi.Models.UserRoles;

namespace OnlaynBazar.WebApi.Validators.UserRoles;

public class UserRoleCreateModelValidator : AbstractValidator<UserRoleCreateModel>
{
    public UserRoleCreateModelValidator()
    {
        RuleFor(userRole => userRole.Name)
            .NotNull()
            .WithMessage(userRole => $"{nameof(userRole.Name)} is not specified");
    }
}