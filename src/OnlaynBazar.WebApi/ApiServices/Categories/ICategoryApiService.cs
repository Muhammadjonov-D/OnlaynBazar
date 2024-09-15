using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Categories;

namespace OnlaynBazar.WebApi.ApiServices.Categories;

public interface ICategoryApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CategoryViewModel> GetAsync(long id);
    ValueTask<CategoryViewModel> PostAsync(CategoryCreateModel createModel);
    ValueTask<CategoryViewModel> PutAsync(long id, CategoryUpdateModel updateModel);
    ValueTask<IEnumerable<CategoryViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
