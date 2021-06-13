using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int UserId { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; }
    }
}
