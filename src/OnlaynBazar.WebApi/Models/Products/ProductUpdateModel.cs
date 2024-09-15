namespace OnlaynBazar.WebApi.Models.Products;

public class ProductUpdateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public bool IsActivestatus { get; set; }
    public long DiscountId { get; set; }
}
