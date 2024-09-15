using FluentValidation;
using OnlaynBazar.WebApi.Models.WareHouses;

namespace OnlaynBazar.WebApi.Validators.WareHouses;

public class WareHouseCreateModelValidator : AbstractValidator<WareHouseCreateModel>
{
    public WareHouseCreateModelValidator()
    {
        RuleFor(wareHouse => wareHouse.Date)
            .NotNull()
            .WithMessage(wareHouse => $"{nameof(wareHouse.Date)} is not specified");

        RuleFor(wareHouse => wareHouse.OrderId)
            .NotNull()
            .WithMessage(wareHouse => $"{nameof(wareHouse.OrderId)} is not specified");
    }
}
