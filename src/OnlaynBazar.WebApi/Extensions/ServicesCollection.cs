using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Service.Helpers;
using OnlaynBazar.Service.Services.Assets;
using OnlaynBazar.Service.Services.CartItems;
using OnlaynBazar.Service.Services.Categories;
using OnlaynBazar.Service.Services.Discounts;
using OnlaynBazar.Service.Services.OrderItems;
using OnlaynBazar.Service.Services.Orders;
using OnlaynBazar.Service.Services.Payments;
using OnlaynBazar.Service.Services.Permissions;
using OnlaynBazar.Service.Services.Products;
using OnlaynBazar.Service.Services.RolePermisisons;
using OnlaynBazar.Service.Services.UserManagements;
using OnlaynBazar.Service.Services.UserRoles;
using OnlaynBazar.Service.Services.Users;
using OnlaynBazar.Service.Services.WereHouses;
using OnlaynBazar.Service.Services.Wishlists;
using OnlaynBazar.WebApi.ApiServices.CardItems;
using OnlaynBazar.WebApi.ApiServices.Categories;
using OnlaynBazar.WebApi.ApiServices.Discounts;
using OnlaynBazar.WebApi.ApiServices.OrderItems;
using OnlaynBazar.WebApi.ApiServices.Orders;
using OnlaynBazar.WebApi.ApiServices.Payments;
using OnlaynBazar.WebApi.ApiServices.Permissions;
using OnlaynBazar.WebApi.ApiServices.Products;
using OnlaynBazar.WebApi.ApiServices.RolePermissions;
using OnlaynBazar.WebApi.ApiServices.UserManagements;
using OnlaynBazar.WebApi.ApiServices.UserRoles;
using OnlaynBazar.WebApi.ApiServices.Users;
using OnlaynBazar.WebApi.ApiServices.WareHouses;
using OnlaynBazar.WebApi.ApiServices.Wishlists;
using OnlaynBazar.WebApi.Helpers;
using OnlaynBazar.WebApi.Middlewares;
using OnlaynBazar.WebApi.Validators.Assests;
using OnlaynBazar.WebApi.Validators.CardItems;
using OnlaynBazar.WebApi.Validators.Categories;
using OnlaynBazar.WebApi.Validators.Discounts;
using OnlaynBazar.WebApi.Validators.OrderItems;
using OnlaynBazar.WebApi.Validators.Orders;
using OnlaynBazar.WebApi.Validators.Payments;
using OnlaynBazar.WebApi.Validators.Permissions;
using OnlaynBazar.WebApi.Validators.Products;
using OnlaynBazar.WebApi.Validators.RolePermissions;
using OnlaynBazar.WebApi.Validators.UserManagements;
using OnlaynBazar.WebApi.Validators.UserRoles;
using OnlaynBazar.WebApi.Validators.Users;
using OnlaynBazar.WebApi.Validators.WareHouses;
using OnlaynBazar.WebApi.Validators.Wishlists;
using System.Text;

namespace OnlaynBazar.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<ICardItemService, CardItemService>();
        services.AddScoped<ICategoryService,CourseCategoryService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaymentService,PaymentService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWareHouseService, WareHouseService>();
        services.AddScoped<IWishlistService, WishlistService>();
    }
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ICardItemApiService, CardItemApiService>();
        services.AddScoped<ICategoryApiService,CategoryApiService>();
        services.AddScoped<IDiscountApiService,DiscountApiService>();
        services.AddScoped<IOrderItemApiService, OrderItemApiService>();
        services.AddScoped<IOrderApiService, OrderApiService>();
        services.AddScoped<IPaymentApiService,PaymentApiService>();
        services.AddScoped<IPermissionApiService, PermissionApiService>();
        services.AddScoped<IProductApiservice,ProductApiService>();
        services.AddScoped<IRolePermissionApiService, RolePermissionApiService>();
        services.AddScoped<IUserManagementApiService, UserManagementApiService>();
        services.AddScoped<IUserRoleApiService, UserRoleApiService>();
        services.AddScoped<IUserApiService, UserApiService>();
        services.AddScoped<IWareHouseApiService, WareHouseApiService>();
        services.AddScoped<IWishlistApiService,WishlistApiService>();
    }
    public static void AddValidators(this IServiceCollection services)
    {
        // User
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();
        //services.AddTransient<UserChangePasswordModelValidator>();

        // UserRole
        services.AddTransient<UserRoleCreateModelValidator>();
        services.AddTransient<UserRoleUpdateModelValidator>();

        // Permision
        services.AddTransient<PermissionCreateModelValidator>();
        services.AddTransient<PermissionUpdateModelValidator>();

        // RolePermission
        services.AddTransient<RolePermissionCreateModelValidator>();

        // UserManagement
        services.AddTransient<UserManagementCreateModelValidator>();
        services.AddTransient<UserManagemnetUpdateModelValidator>();

        // Asset
        services.AddTransient<AssetCreateModelValidator>();

        // ORder
        services.AddTransient<OrderCreateModelValidator>();
        services.AddTransient<OrderUpdateModelValidator>();

        // OrderItem
        services.AddTransient<OrderItemCreateModelValidator>();
        services.AddTransient<OrderItemUpdateModelValidator>();

        // CartItem
        services.AddTransient<CardItemCreateModelValidator>();
        services.AddTransient<CardItemUpdateModelValidator>();

        // Category
        services.AddTransient<CategoryCreateModelValidator>();
        services.AddTransient<CategoryUpdateModelValidator>();

        // Discount
        services.AddTransient<DiscountCreateModelValidator>();
        services.AddTransient<DiscountUpdateModelValidator>();

        // Payment
        services.AddTransient<PaymentCreateModelValidator>();

        // Product
        services.AddTransient<ProductCreateModelValidator>();
        services.AddTransient<ProductUpdateModelValidator>();

        // WereHouse
        services.AddTransient<WareHouseCreateModelValidator>();
        services.AddTransient<WareHouseUpdateModelValidator>();

        // Wishlist
        services.AddTransient<WishlistCreateModelValidator>();
        services.AddTransient<WishlistUpdateModelValidator>();
    }
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }

    public static void AddInjectHelper(this WebApplication serviceProvider)
    {
        var scope = serviceProvider.Services.CreateScope();
        InjectHelper.RolePermissionService = scope.ServiceProvider.GetRequiredService<IRolePermissionService>();
    }

    public static void InjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
        EnvironmentHelper.JWTKey = app.Configuration.GetSection("JWT:Key").Value;
        EnvironmentHelper.TokenLifeTimeInHours = app.Configuration.GetSection("JWT:LifeTime").Value;
        EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:Password").Value;
        EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:Port").Value;
        EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:Host").Value;
        EnvironmentHelper.PageSize = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageSize").Value);
        EnvironmentHelper.PageIndex = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageIndex").Value);
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }
}