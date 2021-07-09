using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.DashboardModels;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class DashboardService
    {
        private readonly IEntityRepository<Room> _roomRepository;

        public DashboardService(IEntityRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var rooms = await _roomRepository.GetAllAsync(query => query.Include(x => x.Images).OrderBy(x => x.InsertDate).Take(3));
            return new DashboardViewModel
            {
                AllRooms = 0,
                BusyRooms = 0,
                Rooms = rooms.ToList()
            };
        }
    }
}
