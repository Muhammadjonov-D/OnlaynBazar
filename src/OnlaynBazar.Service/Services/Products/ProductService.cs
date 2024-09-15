using Microsoft.AspNetCore.Http;
using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.Products;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using OnlaynBazar.Service.Services.Assets;

namespace OnlaynBazar.Service.Services.Products;

public class ProductService(IUnitOfWork unitOfWork, IAssetService assetService) : IProductService
{
    public async ValueTask<Product> CreateAsync(Product product)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(category => category.Id == product.CategoryId && !category.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID = {product.CategoryId}");

        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(discount => discount.Id == product.DiscountId && !discount.IsDeleted)
            ?? throw new NotFoundException($"Discount is not found with this ID = {product.DiscountId}");

        var existProduct = await unitOfWork.Products
            .SelectAsync(p => p.Id == product.Id && p.Name.ToLower() == product.Name.ToLower());

        if (existProduct is not null && !existProduct.IsDeleted)
            throw new AlreadyExistException($"This product is already exist with this Id = {product.Id} and name = {product.Name}");

        product.CreatedByUserId = HttpContextHelper.UserId;
        var createdProduct = await unitOfWork.Products.InsertAsync(product);
        await unitOfWork.SaveAsync();

        createdProduct.DiscountCode = existDiscount;
        return createdProduct;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == id && !product.IsDeleted)
            ?? throw new NotFoundException($"Product is not found with this ID = {id}");

        existProduct.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Products.DeleteAsync(existProduct);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Product> DeleteFileAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existProduct = await unitOfWork.Products
           .SelectAsync(expression: product => product.Id == id && !product.IsDeleted, includes: ["Module", "File", "Comments"])
           ?? throw new NotFoundException($"Product is not found with this ID = {id}");

        await assetService.DeleteAsync(Convert.ToInt64(existProduct.FileId));
        existProduct.FileId = null;
        await unitOfWork.Products.UpdateAsync(existProduct);
        await unitOfWork.SaveAsync();

        return existProduct;
    }

    public async ValueTask<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var products = unitOfWork.Products
            .SelectAsQueryable(expression: lesson => !lesson.IsDeleted, includes: ["DIscount", "File", "Comments"])
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            products = products.Where(product =>
            product.Name.ToLower().Contains(search.ToLower()) ||
            product.Description.ToLower().Contains(search.ToLower()));

        return await products.ToPaginateAsQueryable(@params).ToListAsync(); ;
    }

    public async ValueTask<Product> GetByIdAsync(long id)
    {
        var existProduct = await unitOfWork.Products
            .SelectAsync(expression: product => product.Id == id && !product.IsDeleted, includes: ["Discount", "File", "Comments"])
            ?? throw new NotFoundException($"Product is not found with this ID = {id}");

        return existProduct;
    }

    public async ValueTask<Product> UpdateAsync(long id, Product product)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(category => category.Id == product.CategoryId && !category.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID = {product.CategoryId}");

        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(discount => discount.Id == product.DiscountId && !discount.IsDeleted)
            ?? throw new NotFoundException($"Discount is not found with this ID = {product.DiscountId}");


        var existProduct = await unitOfWork.Products
            .SelectAsync(p => p.Id == product.Id && p.Name.ToLower() == product.Name.ToLower());

        var alreadyExitsProduct = await unitOfWork.Products
            .SelectAsync(l => l.Id == product.CategoryId && l.Name.ToLower() == product.Name.ToLower() && l.Id != id);

        if (alreadyExitsProduct is not null && !alreadyExitsProduct.IsDeleted)
            throw new AlreadyExistException($"This product is already exist with this Id = {product.Id} and name = {product.Name}");

        alreadyExitsProduct.Id = id;
        alreadyExitsProduct.Name = product.Name;
        alreadyExitsProduct.CategoryId = product.CategoryId;
        alreadyExitsProduct.Description = product.Description;
        alreadyExitsProduct.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Products.UpdateAsync(existProduct);
        await unitOfWork.SaveAsync();
        existProduct.Category = existCategory;

        return existProduct;
    }

    public async ValueTask<Product> UploadFileAsync(long id, IFormFile file, FileType fileType)
    {
        await unitOfWork.BeginTransactionAsync();

        var existProduct = await unitOfWork.Products
           .SelectAsync(expression: product => product.Id == id && !product.IsDeleted, includes: ["Category", "File", "Comments"])
           ?? throw new NotFoundException($"Product is not found with this ID = {id}");

        var createdFile = await assetService.UploadAsync(file, fileType);

        existProduct.File = createdFile;
        existProduct.FileId = createdFile.Id;
        existProduct.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Products.UpdateAsync(existProduct);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existProduct;
    }
}
