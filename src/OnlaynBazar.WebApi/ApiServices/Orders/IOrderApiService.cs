using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Orders;

namespace OnlaynBazar.WebApi.ApiServices.Orders;

public interface IOrderApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<OrderViewModel> GetAsync(long id);
    ValueTask<OrderViewModel> PostAsync(OrderCreateModel createModel);
    ValueTask<OrderViewModel> PutAsync(long id, OrderUpdateModel updateModel);
    ValueTask<IEnumerable<OrderViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
