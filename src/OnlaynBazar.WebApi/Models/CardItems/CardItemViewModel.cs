using OnlaynBazar.WebApi.Models.Products;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.Models.CardItems;

public class CardItemViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public ProductViewModel Product { get; set; }
    public decimal Price { get; set; }
    public DateTime AddedAt { get; set; }
}
