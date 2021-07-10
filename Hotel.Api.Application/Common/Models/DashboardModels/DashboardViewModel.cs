using Hotel.Api.Domain.Entities;
using System.Collections.Generic;

namespace Hotel.Api.Application.Common.Models.DashboardModels
{
    public class DashboardViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservations { get; set; }
        public double AllRooms { get; set; }
        public double BusyRooms { get; set; }
    }
}
