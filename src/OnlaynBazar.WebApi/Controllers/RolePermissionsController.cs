using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.RolePermissions;
using OnlaynBazar.WebApi.Models.Commons;
using OnlaynBazar.WebApi.Models.RolePermissions;

namespace OnlaynBazar.WebApi.Controllers;

public class RolePermissionsController(IRolePermissionApiService rolePermissionService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(RolePermissionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await rolePermissionService.PostAsync(createModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await rolePermissionService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await rolePermissionService.GetAsync(id)
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
            Data = await rolePermissionService.GetAsync(@params, filter, search)
        });
    }
}