using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.ReservationModels
{
    public class AddReservationModel
    {
        public ReservationCreateModel ReservationCreateModel { get; set; }
        public List<int> RoomIds { get; set; }
    }
}
