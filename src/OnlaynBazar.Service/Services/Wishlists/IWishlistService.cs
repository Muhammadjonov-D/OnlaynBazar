using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Domain.Entities.Wishlists;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Wishlists;

public interface IWishlistService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Wishlist> GetByIdAsync(long id);
    ValueTask<Wishlist> CreateAsync(Wishlist wishlist);
    ValueTask<Wishlist> UpdateAsync(long id, Wishlist wishlist);
    ValueTask<IEnumerable<Wishlist>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
