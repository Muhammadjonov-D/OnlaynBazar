using AutoMapper;
using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.Orders;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.Orders;
using OnlaynBazar.WebApi.Validators.Orders;

namespace OnlaynBazar.WebApi.ApiServices.Orders;

public class OrderApiService(
    IMapper mapper,
    IOrderService orderService,
    OrderCreateModelValidator createModelValidator,
    OrderUpdateModelValidator updateModelValidator) : IOrderApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await orderService.DeleteAsync(id);
    }

    public async ValueTask<OrderViewModel> GetAsync(long id)
    {
        var CourseComment = await orderService.GetByIdAsync(id);
        return mapper.Map<OrderViewModel>(CourseComment);
    }

    public async ValueTask<IEnumerable<OrderViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseComment = await orderService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<OrderViewModel>>(courseComment);
    }

    public async ValueTask<OrderViewModel> PostAsync(OrderCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedOrder = mapper.Map<Order>(createModel);
        var createdOrder = await orderService.CreateAsync(mappedOrder);
        var returnalble = mapper.Map<OrderViewModel>(createdOrder);

        returnalble.User.FirstName = createdOrder.User.FirstName;
        returnalble.User.LastName = createdOrder.User.LastName;
        returnalble.User.Email = createdOrder.User.Email;
        returnalble.User.PhoneNumber = createdOrder.User.PhoneNumber;

        return returnalble;
    }

    public async ValueTask<OrderViewModel> PutAsync(long id, OrderUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedOrder = mapper.Map<Order>(updateModel);
        var updatedOrder = await orderService.UpdateAsync(id, mappedOrder);
        var returnable = mapper.Map<OrderViewModel>(updatedOrder);

        returnable.User.FirstName = updatedOrder.User.FirstName;
        returnable.User.LastName = updatedOrder.User.LastName;
        returnable.User.Email = updatedOrder.User.Email;
        returnable.User.PhoneNumber = updatedOrder.User.PhoneNumber;
        
        return returnable;
    }
}
