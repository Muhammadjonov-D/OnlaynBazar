using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Permissions;

public interface IPermissionService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Permission> GetByIdAsync(long id);
    ValueTask<Permission> CreateAsync(Permission permission);
    ValueTask<Permission> UpdateAsync(long id, Permission permission);
    ValueTask<IEnumerable<Permission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}