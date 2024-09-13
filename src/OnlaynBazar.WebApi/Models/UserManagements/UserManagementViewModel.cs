using OnlaynBazar.Domain.Enums;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.Models.UserManagements;

public class UserManagementViewModel
{
    public long Id { get; set; }
    public Role Role { get; set; }
    public UserViewModel User { get; set; }
    public AccountStatus Status { get; set; }
}
