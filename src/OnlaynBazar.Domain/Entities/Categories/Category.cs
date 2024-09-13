using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Products;

namespace OnlaynBazar.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
