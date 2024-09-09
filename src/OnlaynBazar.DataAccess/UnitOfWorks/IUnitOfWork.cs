using Arcana.DataAccess.Repositories;
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

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
    IRepository<CardItem> CardItems { get; }
    IRepository<Category> Categories { get; }
    IRepository<DisCountCode> DisCountCodes { get; }
    IRepository<OrderItem> OrderItems { get; }
    IRepository<OrderManagement> OrderManagements { get; }
    IRepository<Order> Orders { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Payment> Payments { get; }
    IRepository<Product> Products { get; }
    IRepository<UserManagement> UserManagements { get; }
    IRepository<WareHouse> WareHouses { get; }
    IRepository<Wishlist> Wishlists { get; }
    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}
