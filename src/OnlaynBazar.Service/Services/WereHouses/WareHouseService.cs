using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Helpers;
using OnlaynBazar.Service.Extensions;
using Microsoft.EntityFrameworkCore;


namespace OnlaynBazar.Service.Services.WereHouses;

public class WareHouseService(IUnitOfWork unitOfWork) : IWareHouseService
{
    public async ValueTask<WareHouse> CreateAsync(WareHouse wareHouse)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(order => order.Id == wareHouse.OrderId && !order.IsDeleted)
             ?? throw new NotFoundException($"Course is not found with this ID = {wareHouse.OrderId}");

        var existWareHouse = await unitOfWork.WareHouses.SelectAsync(module =>
            module.Date == wareHouse.Date &&
            module.OrderId == wareHouse.OrderId && !module.IsDeleted);

        if (existWareHouse is not null)
            throw new AlreadyExistException("This ware house  already exists");

        existWareHouse.CreatedByUserId = HttpContextHelper.UserId;
        var createdWareHouse = await unitOfWork.WareHouses.InsertAsync(wareHouse);
        await unitOfWork.SaveAsync();

        return createdWareHouse;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existWareHouse = await unitOfWork.WareHouses.SelectAsync(w => w.Id == id && !w.IsDeleted)
           ?? throw new NotFoundException($"WareHouse  is not found with this ID={id}");

        existWareHouse.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.WareHouses.DeleteAsync(existWareHouse);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<WareHouse>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var wareHouse = unitOfWork.WareHouses
            .SelectAsQueryable(expression: cm => !cm.IsDeleted, includes: ["House"], isTracked: false)
            .OrderBy(filter);


        return await wareHouse.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<WareHouse> GetByIdAsync(long id)
    {
        var existwareHouse = await unitOfWork.WareHouses
            .SelectAsync(cm => cm.Id == id && !cm.IsDeleted, includes: ["House"])
           ?? throw new NotFoundException($"WareHouse is not found with this ID={id}");

        return existwareHouse;
    }

    public async ValueTask<WareHouse> UpdateAsync(long id, WareHouse wareHouse)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(order => order.Id == wareHouse.OrderId && !order.IsDeleted)
            ?? throw new NotFoundException($"WareHouse is not found with this ID = {wareHouse.OrderId}");

        var existWareHouse = await unitOfWork.WareHouses.SelectAsync(cm => cm.Id == id && !cm.IsDeleted)
            ?? throw new NotFoundException($"Ware House is not found with this Id = {id}");

        existWareHouse.OrderId = wareHouse.OrderId;
        existWareHouse.Date = wareHouse.Date;
        existWareHouse.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.WareHouses.UpdateAsync(existWareHouse);
        await unitOfWork.SaveAsync();

        return existWareHouse;
    }
}
