using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Application.Common.Models.Payment
{
    public class PaymentUpdateModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; } = false;
    }
}
