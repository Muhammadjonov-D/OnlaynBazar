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
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.WebApi.Models.Discounts;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.WebApi.Models.Orders;
using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.WebApi.Models.Categories;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.WebApi.Models.Products;
using OnlaynBazar.Domain.Entities.CardItems;
using OnlaynBazar.WebApi.Models.CardItems;
using OnlaynBazar.Domain.Entities.Wishlists;
using OnlaynBazar.WebApi.Models.Wishlists;
using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.WebApi.Models.WareHouses;
using OnlaynBazar.Domain.Entities.Payments;
using OnlaynBazar.WebApi.Models.Payments;

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

        // Discount
        CreateMap<DisCountCode,DiscountCreateModel>().ReverseMap();
        CreateMap<DisCountCode,DiscountUpdateModel>().ReverseMap();
        CreateMap<DisCountCode,DiscountViewModel>().ReverseMap();

        // Order
        CreateMap<Order, OrderCreateModel>().ReverseMap();
        CreateMap<Order,OrderUpdateModel>().ReverseMap();
        CreateMap<Order,OrderViewModel>().ReverseMap();

        // Category
        CreateMap<Category,CategoryCreateModel>().ReverseMap();
        CreateMap<Category,CategoryUpdateModel>().ReverseMap();
        CreateMap<Category,CategoryViewModel>().ReverseMap();

        // Product
        CreateMap<Product,ProductCreateModel>().ReverseMap();
        CreateMap<Product, ProductUpdateModel>().ReverseMap();
        CreateMap<Product,ProductViewModel>().ReverseMap();

        // CardITem
        CreateMap<CardItem,CardItemCreateModel>().ReverseMap();
        CreateMap<CardItem, CardItemUpdateModel>().ReverseMap();
        CreateMap<CardItem,CardItemViewModel>().ReverseMap();

        // Wishlist
        CreateMap<Wishlist,WishlistCreateModel>().ReverseMap();
        CreateMap<Wishlist,WishlistUpdateModel>().ReverseMap();
        CreateMap<Wishlist, WishlistViewModel>().ReverseMap();

        // WareHouse
        CreateMap<WareHouse,WareHouseCreateModel>().ReverseMap();
        CreateMap<WareHouse,WareHouseUpdateModel>().ReverseMap();
        CreateMap<WareHouse,WareHouseViewModel>().ReverseMap();

        // Payment
        CreateMap<Payment,PaymentCreateModel>().ReverseMap();
        CreateMap<Payment,PaymentViewModel>().ReverseMap();
    }
}