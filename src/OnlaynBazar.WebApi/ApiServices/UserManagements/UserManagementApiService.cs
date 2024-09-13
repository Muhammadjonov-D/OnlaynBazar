using AutoMapper;
using OnlaynBazar.Domain.Entities.UserManagements;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.UserManagements;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.UserManagements;
using OnlaynBazar.WebApi.Validators.UserManagements;

namespace OnlaynBazar.WebApi.ApiServices.UserManagements;

public class UserManagementApiService(
    IMapper mapper,
    IUserManagementService userManagementService,
    UserManagementCreateModelValidator createValidator,
    UserManagemnetUpdateModelValidator updateValidator) : IUserManagementApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await userManagementService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<UserManagementViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var studentCourses = await userManagementService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<UserManagementViewModel>>(studentCourses);
    }

    public async ValueTask<UserManagementViewModel> GetAsync(long id)
    {
        var userManagement = await userManagementService.GetByIdAsync(id);
        return mapper.Map<UserManagementViewModel>(userManagement);
    }

    public async ValueTask<UserManagementViewModel> PostAsync(UserManagementCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedUserManagement = mapper.Map<UserManagement>(createModel);
        var createdUserManagement = await userManagementService.CreateAsync(mappedUserManagement);
        return mapper.Map<UserManagementViewModel>(createdUserManagement);
    }

    public async ValueTask<UserManagementViewModel> PutAsync(long id, UserManagementUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedUser = mapper.Map<UserManagement>(updateModel);
        var updatedUser = await userManagementService.UpdateAsync(id, mappedUser);
        return mapper.Map<UserManagementViewModel>(updatedUser);
    }
}
