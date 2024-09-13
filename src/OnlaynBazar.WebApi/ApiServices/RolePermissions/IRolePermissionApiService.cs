using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.RolePermissions;

namespace OnlaynBazar.WebApi.ApiServices.RolePermissions;

public interface IRolePermissionApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<RolePermissionViewModel> GetAsync(long id);
    ValueTask<RolePermissionViewModel> PostAsync(RolePermissionCreateModel createModel);
    ValueTask<IEnumerable<RolePermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}