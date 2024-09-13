using OnlaynBazar.Service.Services.Permissions;
using OnlaynBazar.Service.Services.RolePermisisons;
using OnlaynBazar.Service.Services.UserRoles;
using OnlaynBazar.Service.Services.Users;

namespace OnlaynBazar.WebApi.Helpers;

public static class InjectHelper
{
    public static IUserService UserService;
    public static IUserRoleService UserRoleService;
    public static IPermissionService PermissionService;
    public static IRolePermissionService RolePermissionService;
}
