using Hotel.Api.Application.Common.Models.ReservationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IReservationService
    {
        Task<int> CreateReservationAsync(ReservationCreateModel model);
        Task<List<ReservationModel>> GetAllReservationAsync(string id);
        Task<ReservationModel> GetReservationByIdAsync(int id);
        Task<ReservationUpdateModel> UpdateReservationAsync(ReservationUpdateModel model);
        Task<bool> DeleteAsync(int id);
        Task<bool> PayAsync(int id);
    }
}
