using System;

namespace Hotel.Api.Application.Common.Models.Reservation
{
    public class ReservationListModel
    {
        public string UserId { get; set; }
        public string User { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PaymentId { get; set; }
    }
}
