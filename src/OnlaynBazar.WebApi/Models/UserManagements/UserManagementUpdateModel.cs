using OnlaynBazar.Domain.Enums;

namespace OnlaynBazar.WebApi.Models.UserManagements;

public class UserManagementUpdateModel
{
    public long UserId { get; set; }
    public Role Role { get; set; }
    public AccountStatus Status { get; set; }
}
