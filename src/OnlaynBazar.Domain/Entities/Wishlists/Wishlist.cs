using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Domain.Entities.Users;

namespace OnlaynBazar.Domain.Entities.Wishlists;

public class Wishlist : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime AddedAt { get; set; }
}
