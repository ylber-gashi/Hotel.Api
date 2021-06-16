using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; } = false;

        public List<Reservation> Reservations { get; set; }
    }
}
