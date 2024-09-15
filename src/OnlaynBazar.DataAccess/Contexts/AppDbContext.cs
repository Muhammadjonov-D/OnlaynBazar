using OnlaynBazar.DataAccess.EntityConfigurations.Commons;
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
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace OnlaynBazar.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<CardItem> CardItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<DisCountCode> DisCountCodes { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderManagement> OrderManagements { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<UserManagement>  UserManagements { get; set; }
    public DbSet<WareHouse> wareHouses { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyConfigurations(modelBuilder);
    }

    private void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IEntityConfiguration)));

        foreach (var type in typesToRegister)
        {
            var configuration = (IEntityConfiguration)Activator.CreateInstance(type);
            configuration.Configure(modelBuilder);
            configuration.SeedData(modelBuilder); // Call the SeedData method
        }
    }
}
