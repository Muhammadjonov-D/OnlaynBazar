using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Domain.Entities.Wishlists;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Wishlists;

public interface IWishlistService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Wishlist> GetByIdAsync(long id);
    ValueTask<Wishlist> CreateAsync(WareHouse wishlist);
    ValueTask<Wishlist> UpdateAsync(long id, WareHouse wishlist);
    ValueTask<IEnumerable<Wishlist>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
