namespace OnlaynBazar.WebApi.Models.CardItems;

public class CardItemUpdateModel
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public decimal Price { get; set; }
    public DateTime AddedAt { get; set; }
}
