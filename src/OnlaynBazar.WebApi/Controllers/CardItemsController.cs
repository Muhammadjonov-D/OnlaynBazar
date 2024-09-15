using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.CardItems;
using OnlaynBazar.WebApi.Models.CardItems;
using OnlaynBazar.WebApi.Models.Commons;

namespace OnlaynBazar.WebApi.Controllers;

public class CardItemsController(ICardItemApiService cardItemApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CardItemCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await cardItemApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CardItemUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await cardItemApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await cardItemApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await cardItemApiService.GetAsync(id)
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
            Data = await cardItemApiService.GetAsync(@params, filter, search)
        });
    }
}
