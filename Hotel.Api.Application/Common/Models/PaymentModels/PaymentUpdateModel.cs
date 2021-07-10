using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Application.Common.Models.PaymentModels
{
    public class PaymentUpdateModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double Total { get; set; }
        public bool IsPayed { get; set; } = false;
    }
}
