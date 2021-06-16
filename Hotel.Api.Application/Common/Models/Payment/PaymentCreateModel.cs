using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Application.Common.Models.Payment
{
    public class PaymentCreateModel
    {
        public string UserId { get; set; }
        public double Price { get; set; } = 0;
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; } = false;
    }
}
