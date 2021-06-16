using Hotel.Api.Application.Common.Models.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IReservationService
    {
        Task<int> CreateReservationAsync(ReservationCreateModel model);
        Task<List<ReservationListModel>> GetAllReservationAsync();
        Task<ReservationModel> GetReservationByIdAsync(int id);
        Task<ReservationUpdateModel> UpdateReservationAsync(ReservationUpdateModel model);
        Task<bool> DeleteAsync(int id);
    }
}
