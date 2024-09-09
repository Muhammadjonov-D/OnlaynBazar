using OnlaynBazar.Domain.Commons;

namespace OnlaynBazar.Domain.Entities.Users;

public class UserRole : Auditable
{
    public string Name { get; set; }
}
