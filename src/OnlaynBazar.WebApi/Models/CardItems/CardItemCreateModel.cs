using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Domain.Entities.Users;

namespace OnlaynBazar.WebApi.Models.CardItems;

public class CardItemCreateModel
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public decimal Price { get; set; }
    public DateTime AddedAt { get; set; }
}
