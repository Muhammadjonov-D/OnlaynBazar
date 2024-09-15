using FluentValidation;
using OnlaynBazar.WebApi.Models.CardItems;

namespace OnlaynBazar.WebApi.Validators.CardItems;

public class CardItemUpdateModelValidator : AbstractValidator<CardItemUpdateModel>
{
    public CardItemUpdateModelValidator()
    {
        RuleFor(cardItem => cardItem.ProductId)
            .NotNull()
            .WithMessage(cardItem => $"{nameof(cardItem.ProductId)} is not specified");

        RuleFor(cardItem => cardItem.Price)
           .NotNull()
           .WithMessage(cardItem => $"{nameof(cardItem.Price)} is not specified");

        RuleFor(cardItem => cardItem.UserId)
          .NotNull()
          .WithMessage(cardItem => $"{nameof(cardItem.UserId)} is not specified");
    }
}
