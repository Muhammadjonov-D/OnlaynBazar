using OnlaynBazar.Service.Configurations;
using OnlaynBazar.WebApi.Models.Payments;

namespace OnlaynBazar.WebApi.ApiServices.Payments;

public interface IPaymentApiService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PaymentViewModel> GetAsync(long id);
    ValueTask<PaymentViewModel> PostAsync(PaymentCreateModel createModel);
    
    ValueTask<IEnumerable<PaymentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
