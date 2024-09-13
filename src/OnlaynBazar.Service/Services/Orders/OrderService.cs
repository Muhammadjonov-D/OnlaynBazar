using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.Orders;

public class OrderService(IUnitOfWork unitOfWork) : IOrderService
{
    public async ValueTask<Order> CreateAsync(Order order)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(c => c.Id == order.UserId && !c.IsDeleted,
            includes: ["Category", "Instructor", "File", "Language"])
            ?? throw new NotFoundException($"Order not found with Id = {order.UserId}");

        order.CreatedByUserId = HttpContextHelper.UserId;
        var created = await unitOfWork.Orders.InsertAsync(order);
        await unitOfWork.SaveAsync();

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(c => c.Id == id && !c.IsDeleted)
           ?? throw new NotFoundException($"Order not found with Id = {id}");

        existOrder.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Orders.DeleteAsync(existOrder);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var orders = unitOfWork.Orders.SelectAsQueryable
            (c => !c.IsDeleted, includes: ["Order"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            orders = orders.Where(o =>
               o.WarehouseAddress.ToLower().Contains(search.ToLower()));

        return await orders.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Order> GetByIdAsync(long id)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(o => o.Id == id && !o.IsDeleted,
            includes: ["User"])
            ?? throw new NotFoundException($"Order not found with Id = {id}");

        return existOrder;
    }

    public async ValueTask<Order> UpdateAsync(long id, Order order)
    {
        await unitOfWork.BeginTransactionAsync();

        var existUser = await unitOfWork.Users.SelectAsync(o => o.Id == order.UserId && !o.IsDeleted,
           includes: ["Category", "Instructor", "File", "Language"])
           ?? throw new NotFoundException($"User not found with Id = {order.UserId}");

        var existOrder = await unitOfWork.Orders.SelectAsync(c => c.Id == id && !c.IsDeleted)
           ?? throw new NotFoundException($"CourseComment not found with Id = {id}");

        existOrder.UpdatedByUserId = HttpContextHelper.UserId;

        var updated = await unitOfWork.Orders.UpdateAsync(existOrder);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return updated;
    }
}
