using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.ReservationModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> AllReservations()
        {
            var reservations = new List<ReservationModel>()
            {
                new ReservationModel
                {
                    Id = 1,
                    UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                    FirstName = "Ylber",
                    LastName = "Gashi",
                    RoomId = 3,
                    RoomNumber = 4,
                    RoomPrice = 299,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now,
                    PaymentId = 3
                },
                new ReservationModel
                {
                    Id = 1,
                    UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                    FirstName = "Ylber",
                    LastName = "Gashi",
                    RoomId = 3,
                    RoomNumber = 4,
                    RoomPrice = 299,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now,
                    PaymentId = 3
                },
                new ReservationModel
                {
                    Id = 1,
                    UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                    FirstName = "Ylber",
                    LastName = "Gashi",
                    RoomId = 3,
                    RoomNumber = 4,
                    RoomPrice = 299,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now,
                    PaymentId = 3
                },

            };
            return View(reservations);
        }

        [HttpGet("reservations/add")]
        public async Task<IActionResult> AddReservationView()
        {
            var model = new AddReservationModel
            {
                RoomIds = new List<int>()
                {
                    1,
                    3,
                    5,
                    6
                }
            };
            return View("AddReservation", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(AddReservationModel model)
        {
            return RedirectToAction("AllReservations");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            return RedirectToAction("AllReservations");
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody] ReservationUpdateModel model)
        //{
        //    return Ok(await _reservationService.UpdateReservationAsync(model));
        //}
    }
}
