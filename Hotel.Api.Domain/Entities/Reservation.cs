using System;

namespace Hotel.Api.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
