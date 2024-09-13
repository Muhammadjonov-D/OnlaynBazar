using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.WebApi.Models.UserManagements;

public class UserManagementCreateModel
{
    public long UserId { get; set; }
    public Role Role { get; set; }
    public AccountStatus Status { get; set; }
}
