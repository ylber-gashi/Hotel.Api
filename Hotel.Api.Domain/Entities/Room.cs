using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Domain.Entities
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }
        public RoomTypes RoomType { get; set; }
        public double Price { get; set; }
        public RoomStatus Status { get; set; }

        public List<RoomImage> Images { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
