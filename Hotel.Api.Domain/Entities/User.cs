using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hotel.Api.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public List<Reservation> Reservations { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
