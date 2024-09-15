using AutoMapper;
using OnlaynBazar.Domain.Entities.OrderItems;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.OrderItems;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.OrderItems;
using OnlaynBazar.WebApi.Validators.OrderItems;

namespace OnlaynBazar.WebApi.ApiServices.OrderItems;

public class OrderItemApiService(
    IMapper mapper,
    IOrderItemService orderItemService,
    OrderItemCreateModelValidator createModelValidator,
    OrderItemUpdateModelValidator updateModelValidator) : IOrderItemApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await orderItemService.DeleteAsync(id);
    }

    public async ValueTask<OrderItemViewModel> GetAsync(long id)
    {
        var orderItem = await orderItemService.GetByIdAsync(id);
        return mapper.Map<OrderItemViewModel>(orderItem);
    }

    public async ValueTask<IEnumerable<OrderItemViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var orderItems = await orderItemService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<OrderItemViewModel>>(orderItems);
    }

    public async ValueTask<OrderItemViewModel> PostAsync(OrderItemCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdOrderItem = await orderItemService.CreateAsync(mapper.Map<OrderItem>(createModel));
        return mapper.Map<OrderItemViewModel>(createdOrderItem);
    }

    public async ValueTask<OrderItemViewModel> PutAsync(long id, OrderItemUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedOrderItem = await orderItemService.UpdateAsync(id, mapper.Map<OrderItem>(updateModel));
        return mapper.Map<OrderItemViewModel>(updatedOrderItem);
    }
}
