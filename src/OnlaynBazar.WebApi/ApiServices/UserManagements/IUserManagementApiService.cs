using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.UserManagements;

namespace OnlaynBazar.WebApi.ApiServices.UserManagements;

public interface IUserManagementApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserManagementViewModel> GetAsync(long id);
    ValueTask<UserManagementViewModel> PostAsync(UserManagementCreateModel createModel);
    ValueTask<UserManagementViewModel> PutAsync(long id, UserManagementUpdateModel updateModel);
    ValueTask<IEnumerable<UserManagementViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
