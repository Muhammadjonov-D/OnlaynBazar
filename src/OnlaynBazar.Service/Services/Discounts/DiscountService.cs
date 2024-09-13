using Microsoft.Extensions.Caching.Memory;
using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.Discounts;

public class DiscountService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IDiscountService
{
    public async ValueTask<DisCountCode> CreateAsync(DisCountCode discount)
    {
        await unitOfWork.BeginTransactionAsync();

        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(
            cc => cc.Code == discount.Code &&
            !cc.IsDeleted);

        if (existDiscount is not null)
            throw new AlreadyExistException("Discount is already exists");

        discount.CreatedByUserId = HttpContextHelper.UserId;

        var created = await unitOfWork.DisCountCodes.InsertAsync(discount);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(
            cc => cc.Id == id &&
            !cc.IsDeleted)
            ?? throw new NotFoundException($"Discount is not found with Id = {id}");

        existDiscount.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.DisCountCodes.DeleteAsync(existDiscount);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<IEnumerable<DisCountCode>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var discounts = unitOfWork.DisCountCodes
            .SelectAsQueryable(expression: discount => !discount.IsDeleted, includes: ["Detail.Role", "Picture"], isTracked: false)
            .OrderBy(filter);

        return await discounts.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<DisCountCode> GetByIdAsync(long id)
    {
        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"Discount is not found with Id = {id}");

        return existDiscount;
    }

    public async ValueTask<DisCountCode> UpdateAsync(long id, DisCountCode discount)
    {
        await unitOfWork.BeginTransactionAsync();

        var existDiscount = await unitOfWork.DisCountCodes.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"Discount is not found with Id = {id}");

        existDiscount.Code = discount.Code;
        existDiscount.UpdatedByUserId = HttpContextHelper.UserId;

        var updated = await unitOfWork.DisCountCodes.UpdateAsync(existDiscount);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return updated;
    }
}
