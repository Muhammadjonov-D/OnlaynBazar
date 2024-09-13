using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Permissions;

namespace OnlaynBazar.WebApi.ApiServices.Permissions;

public interface IPermissionApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PermissionViewModel> GetAsync(long id);
    ValueTask<PermissionViewModel> PostAsync(PermissionCreateModel createModel);
    ValueTask<PermissionViewModel> PutAsync(long id, PermissionUpdateModel updateModel);
    ValueTask<IEnumerable<PermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
