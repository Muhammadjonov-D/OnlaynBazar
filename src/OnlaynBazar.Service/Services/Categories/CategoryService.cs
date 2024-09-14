using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.Categories;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.Categories;

public class CourseCategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    public async ValueTask<Category> CreateAsync(Category category)
    {
        await unitOfWork.BeginTransactionAsync();

        var existcategory = await unitOfWork.Categories.SelectAsync(
            cc => cc.Name.ToLower() == category.Name.ToLower() &&
            !cc.IsDeleted);

        if (existcategory is not null)
            throw new AlreadyExistException("Course Category is already exists");

        category.CreatedByUserId = HttpContextHelper.UserId;

        var created = await unitOfWork.Categories.InsertAsync(category);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existcategory = await unitOfWork.Categories.SelectAsync(
            cc => cc.Id == id &&
            !cc.IsDeleted)
            ?? throw new NotFoundException($"Category is not found with Id = {id}");

        existcategory.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Categories.DeleteAsync(existcategory);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var categories = unitOfWork.Categories
            .SelectAsQueryable(expression: cc => !cc.IsDeleted, isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            categories = categories.Where(cc =>
               cc.Name.ToLower().Contains(search.ToLower()));

        return await categories.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Category> GetByIdAsync(long id)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"Category is not found with Id = {id}");

        return existCategory;
    }

    public async ValueTask<Category> UpdateAsync(long id, Category courseCategory)
    {
        await unitOfWork.BeginTransactionAsync();

        var existcategory = await unitOfWork.Categories.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"Category is not found with Id = {id}");

        existcategory.Name = courseCategory.Name;
        existcategory.UpdatedByUserId = HttpContextHelper.UserId;

        var updated = await unitOfWork.Categories.UpdateAsync(existcategory);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return updated;
    }
}
