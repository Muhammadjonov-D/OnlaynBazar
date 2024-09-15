using AutoMapper;
using OnlaynBazar.Domain.Entities.WareHouses;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.WereHouses;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.WareHouses;
using OnlaynBazar.WebApi.Validators.WareHouses;

namespace OnlaynBazar.WebApi.ApiServices.WareHouses;

public class WareHouseApiService(
    IMapper mapper,
    IWareHouseService wareHouseService,
    WareHouseCreateModelValidator createModelValidator,
    WareHouseUpdateModelValidator updateModelValidator) : IWareHouseApiService

{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await wareHouseService.DeleteAsync(id);
    }

    public async ValueTask<WareHouseViewModel> GetAsync(long id)
    {
        var wareHouse = await wareHouseService.GetByIdAsync(id);
        return mapper.Map<WareHouseViewModel>(wareHouse);
    }

    public async ValueTask<IEnumerable<WareHouseViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var wareHouses = await wareHouseService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<WareHouseViewModel>>(wareHouses);
    }

    public async ValueTask<WareHouseViewModel> PostAsync(WareHouseCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdWareHouse = await wareHouseService.CreateAsync(mapper.Map<WareHouse>(createModel));
        return mapper.Map<WareHouseViewModel>(createdWareHouse);
    }

    public async ValueTask<WareHouseViewModel> PutAsync(long id, WareHouseUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedWareHouse = await wareHouseService.UpdateAsync(id, mapper.Map<WareHouse>(updateModel));
        return mapper.Map<WareHouseViewModel>(updatedWareHouse);
    }
}
