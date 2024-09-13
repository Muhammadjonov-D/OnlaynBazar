using OnlaynBazar.Domain.Entities.UserManagements;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.UserManagements;

public interface IUserManagementService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserManagement> GetByIdAsync(long id);
    ValueTask<UserManagement> CreateAsync(UserManagement userManagement);
    ValueTask<UserManagement> UpdateAsync(long id, UserManagement userManagement);
    ValueTask<IEnumerable<UserManagement>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
