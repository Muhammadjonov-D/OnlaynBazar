using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.ApiServices.Users;
using OnlaynBazar.WebApi.Models.Commons;
using OnlaynBazar.WebApi.Models.Users;

namespace OnlaynBazar.WebApi.Controllers;

public class UsersController(IUserApiService userApiService) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async ValueTask<IActionResult> PostAsync(UserCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, UserUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userApiService.GetAsync(id)
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
            Data = await userApiService.GetAsync(@params, filter, search)
        });
    }

    //[HttpPatch("change-password")]
    //public async ValueTask<IActionResult> ChangePasswordAsync([FromQuery] UserChangePasswordModel userChangePasswordModel)
    //{
    //    return Ok(new Response
    //    {
    //        StatusCode = 200,
    //        Message = "Ok",
    //        Data = await userApiService.ChangePasswordAsync(userChangePasswordModel)
    //    });
    //}
}