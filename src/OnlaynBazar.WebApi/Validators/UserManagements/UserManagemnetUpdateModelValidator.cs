using FluentValidation;
using OnlaynBazar.WebApi.Models.UserManagements;

namespace OnlaynBazar.WebApi.Validators.UserManagements;

public class UserManagemnetUpdateModelValidator : AbstractValidator<UserManagementUpdateModel>
{
    public UserManagemnetUpdateModelValidator()
    {
        RuleFor(userManagement => userManagement.UserId)
        .NotNull()
        .WithMessage(userManagement => $"{nameof(userManagement.UserId)} is not specified");
    }
}
