using System.ComponentModel;

namespace Hotel.Api.Domain.Enumerations
{
    public enum RoomTypes
    {
        [Description("Normal")]
        NORMAL = 0,
        [Description("VIP")]
        VIP = 1
    }
}
