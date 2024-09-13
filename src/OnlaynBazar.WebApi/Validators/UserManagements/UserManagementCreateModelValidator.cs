using FluentValidation;
using OnlaynBazar.WebApi.Models.UserManagements;

namespace OnlaynBazar.WebApi.Validators.UserManagements;

public class UserManagementCreateModelValidator : AbstractValidator<UserManagementCreateModel>
{
    public UserManagementCreateModelValidator()
    {
        RuleFor(userManagement => userManagement.UserId)
        .NotNull()
        .WithMessage(userManagement => $"{nameof(userManagement.UserId)} is not specified");
    }
}
