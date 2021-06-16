using Hotel.Api.Domain.Enumerations;

namespace Hotel.Api.Application.Common.Models.Payment
{
    public class PaymentListModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPayed { get; set; }
    }
}
