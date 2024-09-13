using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.Discounts;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Commons;
using OnlaynBazar.WebApi.Models.Discounts;

namespace OnlaynBazar.WebApi.Controllers;

public class DiscountsController(IDiscountApiService discountApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(DiscountCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await discountApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, DiscountUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await discountApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await discountApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await discountApiService.GetAsync(id)
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
            Data = await discountApiService.GetAsync(@params, filter, search)
        });
    }
}
