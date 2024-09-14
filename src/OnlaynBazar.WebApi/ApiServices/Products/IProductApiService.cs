using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Products;

namespace OnlaynBazar.WebApi.ApiServices.Products;

public interface IProductApiservice
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<ProductViewModel> GetAsync(long id);
    ValueTask<ProductViewModel> DeleteFileAsync(long id);
    ValueTask<ProductViewModel> PostAsync(ProductCreateModel createModel);
    ValueTask<ProductViewModel> PutAsync(long id, ProductUpdateModel updateModel);
    ValueTask<ProductViewModel> UploadFileAsync(long id, AssetCreateModul assetCreateModel);
    ValueTask<IEnumerable<ProductViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
