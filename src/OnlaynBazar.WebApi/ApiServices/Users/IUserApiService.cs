using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.ApiServices.Users;

public interface IUserApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserViewModel> GetAsync(long id);
    ValueTask<UserViewModel> PostAsync(UserCreateModel createModel);
    ValueTask<UserViewModel> PutAsync(long id, UserUpdateModel createModel);
    ValueTask<IEnumerable<UserViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
