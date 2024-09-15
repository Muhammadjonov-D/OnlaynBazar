using AutoMapper;
using OnlaynBazar.Domain.Entities.CardItems;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.CartItems;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.CardItems;
using OnlaynBazar.WebApi.Validators.CardItems;

namespace OnlaynBazar.WebApi.ApiServices.CardItems;

public class CardItemApiService(
    IMapper mapper,
    ICardItemService cardItemService,
    CardItemCreateModelValidator createModelValidator,
    CardItemUpdateModelValidator updateModelValidator) : ICardItemApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await cardItemService.DeleteAsync(id);
    }

    public async ValueTask<CardItemViewModel> GetAsync(long id)
    {
        var cardItem = await cardItemService.GetByIdAsync(id);
        return mapper.Map<CardItemViewModel>(cardItem);
    }

    public async ValueTask<IEnumerable<CardItemViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var cardItems = await cardItemService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CardItemViewModel>>(cardItems);
    }

    public async ValueTask<CardItemViewModel> PostAsync(CardItemCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdCardItem = await cardItemService.CreateAsync(mapper.Map<CardItem>(createModel));
        return mapper.Map<CardItemViewModel>(createdCardItem);
    }

    public async ValueTask<CardItemViewModel> PutAsync(long id, CardItemUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedCardItem = await cardItemService.UpdateAsync(id, mapper.Map<CardItem>(updateModel));
        return mapper.Map<CardItemViewModel>(updatedCardItem);
    }
}
