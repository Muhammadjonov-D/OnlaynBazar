using AutoMapper;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.RolePermisisons;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.RolePermissions;
using OnlaynBazar.WebApi.Validators.RolePermissions;

namespace OnlaynBazar.WebApi.ApiServices.RolePermissions;

public class RolePermissionApiService(
    IMapper mapper,
    IRolePermissionService rolePermissionService,
    RolePermissionCreateModelValidator createValidator) : IRolePermissionApiService
{
    public async ValueTask<RolePermissionViewModel> PostAsync(RolePermissionCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedRolePermission = mapper.Map<RolePermission>(createModel);
        var createdRolePermission = await rolePermissionService.CreateAsync(mappedRolePermission);
        return mapper.Map<RolePermissionViewModel>(createdRolePermission);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await rolePermissionService.DeleteAsync(id);
    }

    public async ValueTask<RolePermissionViewModel> GetAsync(long id)
    {
        var rolePermission = await rolePermissionService.GetByIdAsync(id);
        return mapper.Map<RolePermissionViewModel>(rolePermission);
    }

    public async ValueTask<IEnumerable<RolePermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var rolePermissions = await rolePermissionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<RolePermissionViewModel>>(rolePermissions);
    }
}