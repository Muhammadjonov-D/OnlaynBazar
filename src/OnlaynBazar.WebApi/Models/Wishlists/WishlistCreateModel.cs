using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Domain.Entities.Users;

namespace OnlaynBazar.WebApi.Models.Wishlists;

public class WishlistCreateModel
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public DateTime AddedAt { get; set; }
}
