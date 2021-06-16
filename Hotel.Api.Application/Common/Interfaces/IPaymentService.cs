using Hotel.Api.Application.Common.Models.Payment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<int> CreatePaymentAsync(PaymentCreateModel model);
        Task<List<PaymentListModel>> GetAllPaymentsAsync();
        Task<PaymentModel> GetPaymentByIdAsync(int id);
        Task<PaymentUpdateModel> UpdatePaymentAsync(PaymentUpdateModel model);
        Task<bool> DeleteAsync(int id);
    }
}
