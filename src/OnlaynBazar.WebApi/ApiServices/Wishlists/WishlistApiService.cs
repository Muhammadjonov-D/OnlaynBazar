using AutoMapper;
using OnlaynBazar.Domain.Entities.Wishlists;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.Wishlists;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.Wishlists;
using OnlaynBazar.WebApi.Validators.Wishlists;

namespace OnlaynBazar.WebApi.ApiServices.Wishlists;

public class WishlistApiService(
    IMapper mapper,
    IWishlistService wishlistService,
    WishlistCreateModelValidator createModelValidator,
    WishlistUpdateModelValidator updateModelValidator) : IWishlistApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await wishlistService.DeleteAsync(id);
    }

    public async ValueTask<WishlistViewModel> GetAsync(long id)
    {
        var wishlist = await wishlistService.GetByIdAsync(id);
        return mapper.Map<WishlistViewModel>(wishlist);
    }

    public async ValueTask<IEnumerable<WishlistViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var wishlists = await wishlistService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<WishlistViewModel>>(wishlists);
    }

    public async ValueTask<WishlistViewModel> PostAsync(WishlistCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdWishlist = await wishlistService.CreateAsync(mapper.Map<Wishlist>(createModel));
        return mapper.Map<WishlistViewModel>(createdWishlist);
    }

    public async ValueTask<WishlistViewModel> PutAsync(long id, WishlistUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedWishlist = await wishlistService.UpdateAsync(id, mapper.Map<Wishlist>(updateModel));
        return mapper.Map<WishlistViewModel>(updatedWishlist);
    }
}
