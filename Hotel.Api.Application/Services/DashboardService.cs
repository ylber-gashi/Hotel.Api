using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.DashboardModels;
using Hotel.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class DashboardService
    {
        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            return new DashboardViewModel
            {
                AllRooms = 0,
                BusyRooms = 0,
                Rooms = new List<Room>()
            };
        }
    }
}
