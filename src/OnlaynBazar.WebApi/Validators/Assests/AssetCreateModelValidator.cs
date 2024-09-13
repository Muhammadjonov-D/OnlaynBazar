using OnlaynBazar.WebApi.Models.Assets;
using FluentValidation;

namespace OnlaynBazar.WebApi.Validators.Assests;

public class AssetCreateModelValidator : AbstractValidator<AssetCreateModul>
{
    public AssetCreateModelValidator()
    {
        RuleFor(asset => asset.FileType)
            .NotNull()
            .IsInEnum()
            .WithMessage(asset => $"{nameof(asset.FileType)} is not specified");

        RuleFor(asset => asset.File)
            .NotNull()
            .WithMessage(asset => $"{nameof(asset.FileType)} is not specified");
    }
}