using AutoMapper;
using OnlaynBazar.Domain.Entities.DisCountCodes;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.Discounts;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.Discounts;
using OnlaynBazar.WebApi.Validators.Assests;
using OnlaynBazar.WebApi.Validators.Discounts;

namespace OnlaynBazar.WebApi.ApiServices.Discounts;

public class DiscountApiService(
    IMapper mapper,
    IDiscountService discountService,
    DiscountCreateModelValidator createModelValidator,
    DiscountUpdateModelValidator updateModelValidator) : IDiscountApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await discountService.DeleteAsync(id);
    }

    public async ValueTask<DiscountViewModel> GetAsync(long id)
    {
        var discount = await discountService.GetByIdAsync(id);

        return mapper.Map<DiscountViewModel>(discount);
    }

    public async ValueTask<IEnumerable<DiscountViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessons = await discountService.GetAllAsync(@params, filter, search);

        return mapper.Map<IEnumerable<DiscountViewModel>>(lessons);
    }

    public async ValueTask<DiscountViewModel> PostAsync(DiscountCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedDiscount = mapper.Map<DisCountCode>(createModel);
        var createdDiscount = await discountService.CreateAsync(mappedDiscount);

        return mapper.Map<DiscountViewModel>(createdDiscount);
    }

    public async ValueTask<DiscountViewModel> PutAsync(long id, DiscountUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedDiscount = mapper.Map<DisCountCode>(updateModel);
        var updatedDiscount = await discountService.UpdateAsync(id, mappedDiscount);

        return mapper.Map<DiscountViewModel>(updatedDiscount);
    }
}
