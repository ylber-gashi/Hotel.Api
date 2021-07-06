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

        [HttpGet("reservations")]
        public async Task<IActionResult> AllReservations()
        {
            var result = await _reservationService.GetAllReservationAsync();
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
            return RedirectToAction("AllReservations");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var result = await _reservationService.DeleteAsync(reservationId);
            return RedirectToAction("AllReservations");
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody] ReservationUpdateModel model)
        //{
        //    return Ok(await _reservationService.UpdateReservationAsync(model));
        //}
    }
}
