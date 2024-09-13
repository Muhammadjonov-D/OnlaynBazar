using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Discounts;

namespace OnlaynBazar.WebApi.ApiServices.Discounts;

public interface IDiscountApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<DiscountViewModel> GetAsync(long id);
    ValueTask<DiscountViewModel> PostAsync(DiscountCreateModel createModel);
    ValueTask<DiscountViewModel> PutAsync(long id, DiscountUpdateModel updateModel);
    ValueTask<IEnumerable<DiscountViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
