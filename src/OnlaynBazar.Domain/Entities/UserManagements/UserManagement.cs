using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.Domain.Entities.UserManagements;

public class UserManagement : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
    public AccountStatus Status { get; set; }
}
