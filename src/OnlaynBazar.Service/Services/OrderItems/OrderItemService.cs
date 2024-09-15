using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.OrderItems;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.OrderItems;

public class OrderItemService(IUnitOfWork unitOfWork) : IOrderItemService
{
    public async ValueTask<OrderItem> CreateAsync(OrderItem orderItem)
    {
        var existOrder = await unitOfWork.Orders.SelectAsync(order => order.Id == orderItem.OrderId && !order.IsDeleted)
            ?? throw new NotFoundException($"Order is not found with this Id = {orderItem.OrderId}");

        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == orderItem.ProductId && !orderItem.IsDeleted)
             ?? throw new NotFoundException($"Product is not found with this ID = {orderItem.ProductId}");

        
        var createdOrderItem = await unitOfWork.OrderItems.InsertAsync(orderItem);
        await unitOfWork.SaveAsync();

        createdOrderItem.Product = existProduct;
        createdOrderItem.Order = existOrder;

        return createdOrderItem;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existOrderItem = await unitOfWork.OrderItems.SelectAsync(oi => oi.Id == id && !oi.IsDeleted)
            ?? throw new NotFoundException($"Order item is not found with this Id = {id}");

        existOrderItem.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.OrderItems.DeleteAsync(existOrderItem);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<OrderItem>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var orderItems = unitOfWork.OrderItems
            .SelectAsQueryable(expression: lc => !lc.IsDeleted, includes: ["Order", "Product"], isTracked: false)
            .OrderBy(filter);

        return await orderItems.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<OrderItem> GetByIdAsync(long id)
    {
        var existOrderItem = await unitOfWork.OrderItems
            .SelectAsync(expression: lc => lc.Id == id && !lc.IsDeleted, includes: ["ORder", "PRoduct",])
            ?? throw new NotFoundException($"ORder item is not found with this Id = {id}");

        return existOrderItem;
    }

    public async ValueTask<OrderItem> UpdateAsync(long id, OrderItem orderItem)
    {
        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == orderItem.ProductId && !product.IsDeleted)
            ?? throw new NotFoundException($"Product is not found with this Id = {orderItem.ProductId}");

        var existOrder = await unitOfWork.Orders.SelectAsync(order => order.Id == orderItem.OrderId && !order.IsDeleted)
             ?? throw new NotFoundException($"Order is not found with this ID = {orderItem.OrderId}");

        var existOrderItem = await unitOfWork.OrderItems.SelectAsync(oi => oi.Id == id && !oi.IsDeleted)
            ?? throw new NotFoundException($"Order Item  is not found with this Id = {id}");

        existOrderItem.Quantity = orderItem.Quantity;
        

        await unitOfWork.OrderItems.UpdateAsync(existOrderItem);
        await unitOfWork.SaveAsync();
        existOrderItem.Order = existOrder;
        existOrderItem.Product = existProduct;

        return existOrderItem;
    }
}
