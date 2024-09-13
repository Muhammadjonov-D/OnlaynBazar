using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using OnlaynBazar.Service.Services.Users;
using Microsoft.EntityFrameworkCore;
using OnlaynBazar.Domain.Entities.UserManagements;

namespace OnlaynBazar.Service.Services.UserManagements;

public class UserManagementService(IUnitOfWork unitOfWork, IUserService userService) : IUserManagementService
{
    public async ValueTask<UserManagement> CreateAsync(UserManagement userManagement)
    {
        await unitOfWork.BeginTransactionAsync();

        userManagement.User.RoleId = await GetRoleId();
        await userService.CreateAsync(userManagement.User);

        userManagement.CreatedByUserId = HttpContextHelper.UserId;
        var createdUserManagement = await unitOfWork.UserManagements.InsertAsync(userManagement);

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return createdUserManagement;
    }

    public  async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existUserManagement = await unitOfWork.UserManagements.SelectAsync(userManagement => userManagement.Id == id)
            ?? throw new NotFoundException($"Student is not found with this ID={id}");

        await userService.DeleteAsync(existUserManagement.UserId);
        existUserManagement.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.UserManagements.DeleteAsync(existUserManagement);

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserManagement>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var userManagements = unitOfWork.UserManagements
            .SelectAsQueryable(expression: user => !user.IsDeleted, includes: ["Detail.Role", "Picture"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            userManagements = userManagements.Where(user =>
                user.User.FirstName.ToLower().Contains(search.ToLower()) ||
                user.User.LastName.ToLower().Contains(search.ToLower()));

        return await userManagements.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<UserManagement> GetByIdAsync(long id)
    {
        var existUsermanagement = await unitOfWork.UserManagements
            .SelectAsync(user => user.Id == id && !user.IsDeleted, includes: ["User.Role", "Picture"])
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        return existUsermanagement;
    }

    public async ValueTask<UserManagement> UpdateAsync(long id, UserManagement user)
    {
        var existUserManagement = await unitOfWork.UserManagements.SelectAsync(user => user.Id == id)
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        await userService.UpdateAsync(existUserManagement.UserId, user.User);
        return existUserManagement;
    }
    private async ValueTask<long> GetRoleId()
    {
        var role = await unitOfWork.UserRoles.SelectAsync(role => role.Name.ToLower() == Constants.UserRoleName.ToLower())
            ?? throw new NotFoundException($"Role is not found with this name {Constants.UserRoleName}");

        return role.Id;
    }
}
