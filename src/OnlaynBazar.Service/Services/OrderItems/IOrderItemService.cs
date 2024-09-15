using OnlaynBazar.Domain.Entities.OrderItems;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.OrderItems;

public interface IOrderItemService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<OrderItem> GetByIdAsync(long id);
    ValueTask<OrderItem> CreateAsync(OrderItem orderItem);
    ValueTask<OrderItem> UpdateAsync(long id, OrderItem orderItem);
    ValueTask<IEnumerable<OrderItem>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
