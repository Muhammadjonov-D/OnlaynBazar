using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Wishlists;

namespace OnlaynBazar.WebApi.ApiServices.Wishlists;

public interface IWishlistApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<WishlistViewModel> GetAsync(long id);
    ValueTask<WishlistViewModel> PostAsync(WishlistCreateModel createModel);
    ValueTask<WishlistViewModel> PutAsync(long id, WishlistUpdateModel updateModel);
    ValueTask<IEnumerable<WishlistViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
