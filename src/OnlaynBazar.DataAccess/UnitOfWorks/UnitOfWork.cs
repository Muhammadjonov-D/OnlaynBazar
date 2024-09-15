using Arcana.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using OnlaynBazar.DataAccess.Contexts;
using OnlaynBazar.Domain.Entities.CardItems;
using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.Domain.Entities.Commons;
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.Domain.Entities.OrderItems;
using OnlaynBazar.Domain.Entities.OrderManagements;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Domain.Entities.Payments;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Domain.Entities.UserManagements;
using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Domain.Entities.Wishlists;

namespace OnlaynBazar.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<User> Users { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<RolePermission> RolePermissions { get; }
    public IRepository<Asset> Assets { get; }
    public IRepository<CardItem> CardItems { get; }
    public IRepository<Category> Categories { get; }
    public IRepository<DisCountCode> DisCountCodes { get; }
    public IRepository<OrderItem> OrderItems { get; }
    public IRepository<OrderManagement> OrderManagements { get; }
    public IRepository<Order> Orders { get; }
    public IRepository<Payment> Payments { get; }
    public IRepository<Product> Products { get; }
    public IRepository<UserManagement> UserManagements { get; }
    public IRepository<WareHouse> WareHouses { get; }
    public IRepository<Wishlist> Wishlists { get; }
    private IDbContextTransaction transaction;
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        UserRoles = new Repository<UserRole>(this.context);
        Permissions = new Repository<Permission>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);
        UserManagements = new Repository<UserManagement>(this.context);
        Assets = new Repository<Asset>(this.context);
        DisCountCodes = new Repository<DisCountCode>(this.context);
        Orders = new Repository<Order>(this.context);
        Categories = new Repository<Category>(this.context);
        Products = new Repository<Product>(this.context);
        CardItems = new Repository<CardItem>(this.context);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }


    public async ValueTask BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }


    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}
