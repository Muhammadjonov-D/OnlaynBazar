using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Wishlists;

namespace OnlaynBazar.Domain.Entities.Users;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime OrederHistory { get; set; }
    public long WishlistId { get; set; }
    public Wishlist Wishlist { get; set; }
    public long RoleId { get; set; }
    public UserRole Role { get; set; }
}
