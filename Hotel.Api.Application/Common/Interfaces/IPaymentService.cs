using Hotel.Api.Application.Common.Models.PaymentModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<int> CreatePaymentAsync(PaymentCreateModel model);
        Task<List<PaymentModel>> GetAllPaymentsAsync(string id);
        Task<PaymentModel> GetPaymentByIdAsync(int id);
        Task<PaymentUpdateModel> UpdatePaymentAsync(PaymentUpdateModel model);
        Task<bool> DeleteAsync(int id);
    }
}
