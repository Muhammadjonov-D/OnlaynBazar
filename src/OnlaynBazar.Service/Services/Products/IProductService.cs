using Microsoft.AspNetCore.Http;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Products;

public interface IProductService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Product> GetByIdAsync(long id);
    ValueTask<Product> DeleteFileAsync(long id);
    ValueTask<Product> CreateAsync(Product lesson);
    ValueTask<Product> UpdateAsync(long id, Product product);
    ValueTask<Product> UploadFileAsync(long id, IFormFile file, FileType fileType);
    ValueTask<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
