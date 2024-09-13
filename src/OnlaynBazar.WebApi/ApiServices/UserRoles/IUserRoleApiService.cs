﻿using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.UserRoles;

namespace OnlaynBazar.WebApi.ApiServices.UserRoles;

public interface IUserRoleApiService
{
    ValueTask<UserRoleViewModel> PostAsync(UserRoleCreateModel createModel);
    ValueTask<UserRoleViewModel> PutAsync(long id, UserRoleUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserRoleViewModel> GetAsync(long id);
    ValueTask<IEnumerable<UserRoleViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
