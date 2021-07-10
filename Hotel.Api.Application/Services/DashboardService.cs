using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.DashboardModels;
using Hotel.Api.Domain.Entities;
using Hotel.Api.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IEntityRepository<Room> _roomRepository;
        private readonly IEntityRepository<Reservation> _reservationRepository;

        public DashboardService(IEntityRepository<Room> roomRepository, IEntityRepository<Reservation> reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var rooms = await _roomRepository.GetAllAsync(query => query.Include(x => x.Images).OrderBy(x => x.InsertDate));
            var reservations = await _reservationRepository.GetAllAsync();
            return new DashboardViewModel
            {
                AllRooms = rooms.Count,
                Reservations = reservations.ToList(),
                BusyRooms = reservations.Where(x => x.CheckOutDate >= DateTime.Now).ToList().Count,
                Rooms = rooms.ToList()
            };
        }
    }
}
