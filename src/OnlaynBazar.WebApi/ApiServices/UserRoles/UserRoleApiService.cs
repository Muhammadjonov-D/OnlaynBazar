using AutoMapper;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.UserRoles;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.UserRoles;
using OnlaynBazar.WebApi.Validators.UserRoles;

namespace OnlaynBazar.WebApi.ApiServices.UserRoles;

public class UserRoleApiService(
    IMapper mapper,
    IUserRoleService userRoleService,
    UserRoleCreateModelValidator createValidator,
    UserRoleUpdateModelValidator updateValidator) : IUserRoleApiService
{
    public async ValueTask<UserRoleViewModel> PostAsync(UserRoleCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedUserRole = mapper.Map<UserRole>(createModel);
        var createdUserRole = await userRoleService.CreateAsync(mappedUserRole);
        return mapper.Map<UserRoleViewModel>(createdUserRole);
    }

    public async ValueTask<UserRoleViewModel> PutAsync(long id, UserRoleUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedUserRole = mapper.Map<UserRole>(updateModel);
        var updatedUserRole = await userRoleService.UpdateAsync(id, mappedUserRole);
        return mapper.Map<UserRoleViewModel>(updatedUserRole);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await userRoleService.DeleteAsync(id);
    }

    public async ValueTask<UserRoleViewModel> GetAsync(long id)
    {
        var userRole = await userRoleService.GetByIdAsync(id);
        return mapper.Map<UserRoleViewModel>(userRole);
    }

    public async ValueTask<IEnumerable<UserRoleViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var userRoles = await userRoleService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<UserRoleViewModel>>(userRoles);
    }
}