using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.ReservationModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;

        public ReservationsController(IReservationService reservationService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        [HttpGet("reservations/{userId}")]
        public async Task<IActionResult> AllReservations(string userId)
        {
            var result = await _reservationService.GetAllReservationAsync(userId);
            return View(result);
        }

        [HttpGet("reservations/add")]
        public async Task<IActionResult> AddReservationView()
        {
            var model = new AddReservationModel
            {
                RoomIds = await _roomService.GetAllRoomIdsAsync()
            };
            return View("AddReservation", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(AddReservationModel model)
        {
            var result = await _reservationService.CreateReservationAsync(model.ReservationCreateModel);
            if(result > 0)
            {
                return RedirectToAction("GetByIdAsync", "Payments", new { id = result });
            }
            return RedirectToAction("AddReservationView");
        }

        [HttpGet("/delete")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var result = await _reservationService.DeleteAsync(reservationId);
            return RedirectToAction("AllReservations");
        }

        [HttpGet("/pay/{id}")]
        public async Task<IActionResult> Pay(int id)
        {
            var result = await _reservationService.PayAsync(id);
            return RedirectToAction("Dashboard","Dashboard");
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody] ReservationUpdateModel model)
        //{
        //    return Ok(await _reservationService.UpdateReservationAsync(model));
        //}
    }
}
