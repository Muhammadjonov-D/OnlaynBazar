using OnlaynBazar.Domain.Commons;

namespace OnlaynBazar.Domain.Entities.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}
