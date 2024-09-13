namespace OnlaynBazar.WebApi.Models.Discounts;

public class DiscountViewModel
{
    public long Id {  get; set; }
    public long Code { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public long Usagelimit { get; set; }
    public decimal MinPurchaseAmount { get; set; }
}
