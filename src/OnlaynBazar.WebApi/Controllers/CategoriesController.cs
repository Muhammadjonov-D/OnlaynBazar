using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.Categories;
using OnlaynBazar.WebApi.Models.Categories;
using OnlaynBazar.WebApi.Models.Commons;

namespace OnlaynBazar.WebApi.Controllers;

public class CategoriesController(ICategoryApiService categoryApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CategoryCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await categoryApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CategoryUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await categoryApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await categoryApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await categoryApiService.GetAsync(id)
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
            Data = await categoryApiService.GetAsync(@params, filter, search)
        });
    }
}
