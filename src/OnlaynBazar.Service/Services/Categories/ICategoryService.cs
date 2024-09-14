using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Categories;

public interface ICategoryService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Category> GetByIdAsync(long id);
    ValueTask<Category> CreateAsync(Category category);
    ValueTask<Category> UpdateAsync(long id, Category category);
    ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
