using Microsoft.AspNetCore.Http;
using OnlaynBazar.Domain.Entities.Commons;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Assets;

public interface IAssetService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Asset> GetByIdAsync(long id);
    ValueTask<Asset> UploadAsync(IFormFile file, FileType type);
}
