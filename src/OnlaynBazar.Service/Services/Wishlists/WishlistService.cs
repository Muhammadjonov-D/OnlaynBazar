using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.Wishlists;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.Wishlists;

public class WishlistService(IUnitOfWork unitOfWork) : IWishlistService
{
    public async ValueTask<Wishlist> CreateAsync(Wishlist wishlist)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == wishlist.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {wishlist.UserId}");

        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == wishlist.ProductId && !product.IsDeleted)
             ?? throw new NotFoundException($"PRoduct is not found with this ID = {wishlist.ProductId}");

        wishlist.CreatedByUserId = HttpContextHelper.UserId;
        var createdWishlist = await unitOfWork.Wishlists.InsertAsync(wishlist);
        await unitOfWork.SaveAsync();

        createdWishlist.Product = existProduct;
        createdWishlist.User = existUser;
        return createdWishlist;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existWishlist = await unitOfWork.Wishlists.SelectAsync(lc => lc.Id == id && !lc.IsDeleted)
            ?? throw new NotFoundException($"Wishlist is not found with this Id = {id}");

        existWishlist.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Wishlists.DeleteAsync(existWishlist);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Wishlist>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var wishlists = unitOfWork.Wishlists
            .SelectAsQueryable(expression: lc => !lc.IsDeleted, includes: ["Product", "User"], isTracked: false)
            .OrderBy(filter);


        return await wishlists.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Wishlist> GetByIdAsync(long id)
    {
        var existWishlist = await unitOfWork.Wishlists
            .SelectAsync(expression: lc => lc.Id == id && !lc.IsDeleted, includes: ["Product", "User"])
            ?? throw new NotFoundException($"Wishlist  is not found with this Id = {id}");

        return existWishlist;
    }

    public async ValueTask<Wishlist> UpdateAsync(long id, Wishlist wishlist)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == wishlist.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {wishlist.UserId}");

        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == wishlist.ProductId && !product.IsDeleted)
             ?? throw new NotFoundException($"Product is not found with this ID = {wishlist.ProductId}");

        var existWishlist = await unitOfWork.Wishlists.SelectAsync(w => w.Id == id && !w.IsDeleted)
            ?? throw new NotFoundException($"Wishlist comment is not found with this Id = {id}");

        existWishlist.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Wishlists.UpdateAsync(existWishlist);
        await unitOfWork.SaveAsync();
        existWishlist.Product = existProduct;
        existWishlist.User = existUser;

        return existWishlist;
    }
}
