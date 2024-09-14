using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.Products;
using OnlaynBazar.WebApi.Models.Assets;
using OnlaynBazar.WebApi.Models.Commons;
using OnlaynBazar.WebApi.Models.Products;

namespace OnlaynBazar.WebApi.Controllers;

public class ProductsController(IProductApiservice productApiservice) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(ProductCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await productApiservice.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, ProductUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await productApiservice.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await productApiservice.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await productApiservice.GetAsync(id)
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
            Data = await productApiservice.GetAllAsync(@params, filter, search)
        });
    }

    [HttpPost("{id:long}/files/upload")]
    public async Task<IActionResult> PictureUploadAsync(long id, AssetCreateModul asset)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await productApiservice.UploadFileAsync(id, asset)
        });
    }

    [HttpPost("{id:long}/files/delete")]
    public async Task<IActionResult> PictureDeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await productApiservice.DeleteFileAsync(id)
        });
    }
}
