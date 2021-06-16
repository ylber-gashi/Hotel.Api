using Hotel.Api.Application.Common.Models.Reservation;
using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.Payment
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; } = false;
        public List<ReservationListModel> Reservations { get; set; }
    }
}
