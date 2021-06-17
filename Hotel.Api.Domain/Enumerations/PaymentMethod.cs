using System.ComponentModel;

namespace Hotel.Api.Domain.Enumerations
{
    public enum PaymentMethod
    {
        [Description("Cash")]
        CASH = 0,
        [Description("Credit Card")]
        CREDITCARD = 1
    }
}
