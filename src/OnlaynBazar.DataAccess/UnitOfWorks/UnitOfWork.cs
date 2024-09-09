using Arcana.DataAccess.Repositories;
using OnlaynBazar.Domain.Entities.Commons;
using OnlaynBazar.Domain.Entities.Users;

namespace OnlaynBazar.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public IRepository<User> Users => throw new NotImplementedException();

    public IRepository<Asset> Assets => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
