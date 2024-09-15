using OnlaynBazar.DataAccess.UnitOfWorks;
using OnlaynBazar.Domain.Entities.Payments;
using OnlaynBazar.Service.Configurations;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.Service.Extensions;
using OnlaynBazar.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OnlaynBazar.Service.Services.Payments;

public class PaymentService(IUnitOfWork unitOfWork) : IPaymentService
{
    public async ValueTask<Payment> CreateAsync(Payment payment)
    {
        var order = await unitOfWork.Orders.SelectAsync(order => order.Id == payment.OrderId)
            ?? throw new NotFoundException($"Question is not found with this ID={payment.OrderId}");

        payment.CreatedByUserId = HttpContextHelper.UserId;
        var createdPayment = await unitOfWork.Payments.InsertAsync(payment);
        await unitOfWork.SaveAsync();
        createdPayment.Order = order;

        return createdPayment;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existPayment = await unitOfWork.Payments.SelectAsync(payment => payment.Id == id && !payment.IsDeleted)
           ?? throw new NotFoundException($"Payment is not found with this ID={id}");

        existPayment.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Payments.DeleteAsync(existPayment);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var payments = unitOfWork.Payments.
            SelectAsQueryable(expression: payment => !payment.IsDeleted,
            includes: ["Question"],
            isTracked: false)
            .OrderBy(filter);

        return await payments.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Payment> GetByIdAsync(long id)
    {
        var existPayment = await unitOfWork.Payments
           .SelectAsync(payment => payment.Id == id && !payment.IsDeleted,
           includes: ["Payment"])
           ?? throw new NotFoundException($"Payment is not found with this ID={id}");

        return existPayment;
    }

    public async ValueTask<Payment> UpdateAsync(long id, Payment payment)
    {
        var existPayment = await unitOfWork.Payments.SelectAsync(payment => payment.Id == id && !payment.IsDeleted)
            ?? throw new NotFoundException($"Payment is not found with this ID={id}");

        existPayment.Amount = payment.Amount;

        existPayment.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Payments.UpdateAsync(existPayment);
        await unitOfWork.SaveAsync();

        return existPayment;
    }
}
