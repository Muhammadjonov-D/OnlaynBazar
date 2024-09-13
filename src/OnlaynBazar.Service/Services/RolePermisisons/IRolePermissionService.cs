using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.RolePermisisons;

public interface IRolePermissionService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<RolePermission> GetByIdAsync(long id);
    ValueTask<RolePermission> CreateAsync(RolePermission rolePermission);
    ValueTask<IEnumerable<RolePermission>> GetAllByRoleIdAsync(long roleId);
    bool CheckRolePermission(string role, string action, string controller);
    ValueTask<IEnumerable<RolePermission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}