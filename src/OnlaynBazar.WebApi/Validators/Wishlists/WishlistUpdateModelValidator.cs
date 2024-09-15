using FluentValidation;
using OnlaynBazar.WebApi.Models.Wishlists;

namespace OnlaynBazar.WebApi.Validators.Wishlists;

public class WishlistUpdateModelValidator : AbstractValidator<WishlistUpdateModel>
{
    public WishlistUpdateModelValidator()
    {
        RuleFor(wishlist => wishlist.ProductId)
            .NotNull()
            .WithMessage(wishlist => $"{nameof(wishlist.ProductId)} is not specified");

       
        RuleFor(wishlist => wishlist.UserId)
          .NotNull()
          .WithMessage(wishlist => $"{nameof(wishlist.UserId)} is not specified");
    }
}
