using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.WereHouses;

public interface IWareHouseService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<WareHouse> GetByIdAsync(long id);
    ValueTask<WareHouse> CreateAsync(WareHouse wareHouse);
    ValueTask<WareHouse> UpdateAsync(long id, WareHouse wareHouse);
    ValueTask<IEnumerable<WareHouse>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
