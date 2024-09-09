using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.Domain.Entities.Commons;

namespace OnlaynBazar.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long? FileId { get; set; }
    public Asset File { get; set; }
    public bool IsActivestatus { get; set; }
    public long DiscountId { get; set; }
}
