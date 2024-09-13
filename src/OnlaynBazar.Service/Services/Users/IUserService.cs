using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Users;

public interface IUserService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> GetByIdAsync(long id);
    ValueTask<User> CreateAsync(User user);
    ValueTask<bool> SendCodeAsync(string phone);
    ValueTask<User> UpdateAsync(long id, User user);
    ValueTask<bool> ConfirmCodeAsync(string phone, string code);
    ValueTask<bool> ResetPasswordAsync(string phone, string newPassword);
    ValueTask<(User user, string token)> LoginAsync(string phone, string password);
    ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword);
    ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
