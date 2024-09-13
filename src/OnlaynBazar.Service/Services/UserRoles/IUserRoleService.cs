using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.UserRoles;

public interface IUserRoleService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserRole> GetByIdAsync(long id);
    ValueTask<UserRole> CreateAsync(UserRole userRole);
    ValueTask<UserRole> UpdateAsync(long id, UserRole userRole);
    ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
