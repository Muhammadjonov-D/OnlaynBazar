using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.WebApi.Models.Assets;

public class AssetCreateModul
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}
