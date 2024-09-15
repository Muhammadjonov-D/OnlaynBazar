using OnlaynBazar.Domain.Entities.Payments;
using OnlaynBazar.Service.Configurations;

namespace OnlaynBazar.Service.Services.Payments;

public interface IPaymentService
{
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Payment> GetByIdAsync(long id);
    ValueTask<Payment> CreateAsync(Payment payment);
    ValueTask<Payment> UpdateAsync(long id, Payment payment);
    ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
