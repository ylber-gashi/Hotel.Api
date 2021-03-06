using Hotel.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<RoomImage> RoomImages { get; set; }
    }
}
