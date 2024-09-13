using OnlaynBazar.Domain.Entities.Users;
using OnlaynBazar.Domain.Entities.Wishlists;

namespace OnlaynBazar.WebApi.Models.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime OrederHistory { get; set; }
    public long WishlistId { get; set; }
    public Wishlist Wishlist { get; set; }
    public long RoleId { get; set; }
    public UserRole UserRole { get; set; }
}
