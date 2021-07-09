using Hotel.Api.Application.Common.Models.ReservationModels;
using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.PaymentModels
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Price { get; set; }
        public bool IsPayed { get; set; }
        public List<ReservationModel> Reservations { get; set; }
    }
}