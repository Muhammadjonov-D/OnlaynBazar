using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.CardItems;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.CartItems;

public class CardItemService(IUnitOfWork unitOfWork) : ICardItemService
{
    public async ValueTask<CardItem> CreateAsync(CardItem cardItem)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == cardItem.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {cardItem.UserId}");

        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == cardItem.ProductId && !product.IsDeleted)
             ?? throw new NotFoundException($"Lesson is not found with this ID = {cardItem.ProductId}");

        //cardItem.Price = cardItem.Price == 0 ? null : cardItem.Price;
        cardItem.CreatedByUserId = HttpContextHelper.UserId;
        var createdCardItem = await unitOfWork.CardItems.InsertAsync(cardItem);
        await unitOfWork.SaveAsync();

        createdCardItem.Product = existProduct;
        createdCardItem.User = existUser;
        return createdCardItem;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCardItem = await unitOfWork.CardItems.SelectAsync(lc => lc.Id == id && !lc.IsDeleted)
           ?? throw new NotFoundException($"CardItem comment is not found with this Id = {id}");

        existCardItem.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.CardItems.DeleteAsync(existCardItem);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<CardItem>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var CardItems = unitOfWork.CardItems
            .SelectAsQueryable(expression: lc => !lc.IsDeleted, includes: ["Product", "User"], isTracked: false)
            .OrderBy(filter);

        return await CardItems.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<CardItem> GetByIdAsync(long id)
    {
        var existCardItem = await unitOfWork.CardItems
            .SelectAsync(expression: lc => lc.Id == id && !lc.IsDeleted, includes: ["User", "Product"])
            ?? throw new NotFoundException($"CardItem comment is not found with this Id = {id}");

        return existCardItem;
    }

    public async ValueTask<CardItem> UpdateAsync(long id, CardItem cardItem)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == cardItem.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {cardItem.UserId}");

        var existProduct = await unitOfWork.Products.SelectAsync(product => product.Id == cardItem.ProductId && !product.IsDeleted)
             ?? throw new NotFoundException($"Product is not found with this ID = {cardItem.ProductId}");

        var existCardItem = await unitOfWork.CardItems.SelectAsync(c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"CardItem comment is not found with this Id = {id}");

        existCardItem.Price = cardItem.Price;
        existProduct.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.CardItems.UpdateAsync(existCardItem);
        await unitOfWork.SaveAsync();
        existCardItem.Product = existProduct;
        existCardItem.User = existUser;

        return existCardItem;
    }
}
