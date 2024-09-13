using AutoMapper;
using OnlaynBazar.Domain.Entities.Commons;
using OnlaynBazar.Domain.Entities.UserManagements;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Permissions;
using OnlaynBazar.WebApi.Models.RolePermissions;
using OnlaynBazar.WebApi.Models.UserRoles;
using OnlaynBazar.WebApi.Models.Users;
using OnlaynBazar.WebApi.Models.Assets;

namespace OnlaynBazar.WebApi.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();

        // UserRole
        CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();

        // Permission
        CreateMap<PermissionViewModel, Permission>().ReverseMap();
        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();

        // RolePermission
        CreateMap<RolePermissionViewModel, RolePermission>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateModel>().ReverseMap();

        // UserManagement
        CreateMap<UserManagement,UserCreateModel>().ReverseMap();
        CreateMap<UserManagement, UserUpdateModel>().ReverseMap();
        CreateMap<UserManagement,UserRoleViewModel>().ReverseMap();

        // Asset
        CreateMap<AssetViewModul, Asset>().ReverseMap();
    }
}