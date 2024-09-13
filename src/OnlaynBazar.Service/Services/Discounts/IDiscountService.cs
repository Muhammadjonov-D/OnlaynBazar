using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Discounts;

public interface IDiscountService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<DisCountCode> GetByIdAsync(long id);
    ValueTask<DisCountCode> CreateAsync(DisCountCode discount);
    ValueTask<DisCountCode> UpdateAsync(long id, DisCountCode discount);
    ValueTask<IEnumerable<DisCountCode>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
