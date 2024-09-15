namespace OnlaynBazar.WebApi.Models.Wishlists;

public class WishlistUpdateModel
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public DateTime AddedAt { get; set; }
}
