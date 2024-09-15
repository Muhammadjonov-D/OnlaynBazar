using OnlaynBazar.Domain.Entities.CardItems;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.CartItems;

public interface ICardItemService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CardItem> GetByIdAsync(long id);
    ValueTask<CardItem> CreateAsync(CardItem cardItem);
    ValueTask<CardItem> UpdateAsync(long id, CardItem cardItem);
    ValueTask<IEnumerable<CardItem>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
