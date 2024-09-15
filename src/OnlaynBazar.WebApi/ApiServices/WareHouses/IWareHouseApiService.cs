using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.WareHouses;

namespace OnlaynBazar.WebApi.ApiServices.WareHouses;

public interface IWareHouseApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<WareHouseViewModel> GetAsync(long id);
    ValueTask<WareHouseViewModel> PostAsync(WareHouseCreateModel createModel);
    ValueTask<WareHouseViewModel> PutAsync(long id, WareHouseUpdateModel updateModel);
    ValueTask<IEnumerable<WareHouseViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
