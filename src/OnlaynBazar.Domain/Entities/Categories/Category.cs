using OnlaynBazar.Domain.Commons;

namespace OnlaynBazar.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
}
