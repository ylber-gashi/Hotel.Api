using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.PaymentModels
{
    public class PaymentCreateModel
    {
        public string UserId { get; set; }
        public List<string> ReservationIds { get; set; }
        public double Price { get; set; } = 0;
    }
}
