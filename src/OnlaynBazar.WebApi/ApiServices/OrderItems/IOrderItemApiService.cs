using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.OrderItems;

namespace OnlaynBazar.WebApi.ApiServices.OrderItems;

public interface IOrderItemApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<OrderItemViewModel> GetAsync(long id);
    ValueTask<OrderItemViewModel> PostAsync(OrderItemCreateModel createModel);
    ValueTask<OrderItemViewModel> PutAsync(long id, OrderItemUpdateModel updateModel);
    ValueTask<IEnumerable<OrderItemViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
