using System;

namespace Hotel.Api.Application.Common.Models.Reservation
{
    public class ReservationUpdateModel
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
