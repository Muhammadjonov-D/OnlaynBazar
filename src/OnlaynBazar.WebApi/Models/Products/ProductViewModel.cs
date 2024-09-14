using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.Domain.Entities.Commons;
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Categories;
using OnlaynBazar.WebApi.Models.Discounts;

namespace OnlaynBazar.WebApi.Models.Products;

public class ProductViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryViewModel Category { get; set; }
    public AssetViewModul File { get; set; }
    public bool IsActivestatus { get; set; }
    public DiscountViewModel DiscountCode { get; set; }
}
