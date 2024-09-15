using AutoMapper;
using OnlaynBazar.Domain.Entities.Payments;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Services.Payments;
using OnlaynBazar.WebApi.Extensions;
using OnlaynBazar.WebApi.Models.Payments;
using OnlaynBazar.WebApi.Validators.Payments;

namespace OnlaynBazar.WebApi.ApiServices.Payments;

public class PaymentApiService(
    IMapper mapper, IPaymentService paymentService,
    PaymentCreateModelValidator createValidator) : IPaymentApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await paymentService.DeleteAsync(id);
    }

    public async ValueTask<PaymentViewModel> GetAsync(long id)
    {
        var payment = await paymentService.GetByIdAsync(id);
        return mapper.Map<PaymentViewModel>(payment);
    }

    public async ValueTask<IEnumerable<PaymentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var payments = await paymentService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<PaymentViewModel>>(payments);
    }

    public async ValueTask<PaymentViewModel> PostAsync(PaymentCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedPayment = mapper.Map<Payment>(createModel);
        var createdPayment = await paymentService.CreateAsync(mappedPayment);
        return mapper.Map<PaymentViewModel>(createdPayment);
    }
}
