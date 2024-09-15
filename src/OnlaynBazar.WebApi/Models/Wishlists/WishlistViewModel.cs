using OnlaynBazar.WebApi.Models.Products;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.Models.Wishlists;

public class WishlistViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public ProductViewModel Product { get; set; }
    public DateTime AddedAt { get; set; }
}
