using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.DataAccess.EntityConfigurations.Commons;

public interface IEntityConfiguration
{
    void Configure(ModelBuilder modelBuilder);
    void SeedData(ModelBuilder modelBuilder);
}
