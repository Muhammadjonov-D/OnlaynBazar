using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.CardItems;

namespace OnlaynBazar.WebApi.ApiServices.CardItems;

public interface ICardItemApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CardItemViewModel> GetAsync(long id);
    ValueTask<CardItemViewModel> PostAsync(CardItemCreateModel createModel);
    ValueTask<CardItemViewModel> PutAsync(long id, CardItemUpdateModel updateModel);
    ValueTask<IEnumerable<CardItemViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
