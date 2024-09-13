using OnlaynBazar.WebApi.Models.Permissions;
using OnlaynBazar.WebApi.Models.UserRoles;

namespace OnlaynBazar.WebApi.Models.RolePermissions;

public class RolePermissionViewModel
{
    public long Id { get; set; }
    public UserRoleViewModel Role { get; set; }
    public PermissionViewModel Permission { get; set; }
}
