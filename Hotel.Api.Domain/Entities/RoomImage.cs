namespace Hotel.Api.Domain.Entities
{
    public class RoomImage : BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string URL { get; set; }
    }
}
