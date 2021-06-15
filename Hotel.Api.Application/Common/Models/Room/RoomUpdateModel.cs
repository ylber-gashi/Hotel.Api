using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Application.Common.Models.Room
{
    public class RoomUpdateModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }
        public RoomTypes RoomType { get; set; }
        public double Price { get; set; }

    }
}
