using System;

namespace Hotel.Api.Application.Common.Models.Reservation
{
    public class ReservationModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double RoomPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PaymentId { get; set; }
    }
}
