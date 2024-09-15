using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.OrderItems;
using OnlaynBazar.WebApi.Models.Commons;
using OnlaynBazar.WebApi.Models.OrderItems;

namespace OnlaynBazar.WebApi.Controllers;

public class OrderItemsController(IOrderItemApiService orderItemApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(OrderItemCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await orderItemApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, OrderItemUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await orderItemApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await orderItemApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await orderItemApiService.GetAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await orderItemApiService.GetAsync(@params, filter, search)
        });
    }
}
