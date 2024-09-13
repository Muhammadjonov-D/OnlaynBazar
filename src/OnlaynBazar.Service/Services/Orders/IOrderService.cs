using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Orders;

public interface IOrderService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Order> GetByIdAsync(long id);
    ValueTask<Order> CreateAsync(Order order);
    ValueTask<Order> UpdateAsync(long id, Order order);
    ValueTask<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
