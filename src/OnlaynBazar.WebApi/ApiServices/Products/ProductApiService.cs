using AutoMapper;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.Products;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Products;
using OnlaynBazar.WebApi.Validators.Assests;
using OnlaynBazar.WebApi.Validators.Products;

namespace OnlaynBazar.WebApi.ApiServices.Products;

public class ProductApiService(
    IMapper mapper,
    IProductService productService,
    ProductCreateModelValidator createModelValidator,
    ProductUpdateModelValidator updateModelValidator,
    AssetCreateModelValidator assetValidator) : IProductApiservice
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await productService.DeleteAsync(id);
    }

    public async ValueTask<ProductViewModel> DeleteFileAsync(long id)
    {
        var product = await productService.DeleteFileAsync(id);
        return mapper.Map<ProductViewModel>(product);
    }

    public async ValueTask<ProductViewModel> GetAsync(long id)
    {
        var product = await productService.GetByIdAsync(id);
        return mapper.Map<ProductViewModel>(product);
    }

    public async ValueTask<IEnumerable<ProductViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var products = await productService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<ProductViewModel>>(products);
    }

    public async  ValueTask<ProductViewModel> PostAsync(ProductCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedProduct = mapper.Map<Product>(createModel);
        var createdProduct = await productService.CreateAsync(mappedProduct);
        return mapper.Map<ProductViewModel>(createdProduct);
    }

    public async ValueTask<ProductViewModel> PutAsync(long id, ProductUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedProduct = mapper.Map<Product>(updateModel);
        var updatedProduct = await productService.UpdateAsync(id, mappedProduct);
        return mapper.Map<ProductViewModel>(updatedProduct);
    }

    public async ValueTask<ProductViewModel> UploadFileAsync(long id, AssetCreateModul assetCreateModel)
    {
        await assetValidator.EnsureValidatedAsync(assetCreateModel);
        var product = await productService.UploadFileAsync(id, assetCreateModel.File, assetCreateModel.FileType);
        return mapper.Map<ProductViewModel>(product);
    }
}
