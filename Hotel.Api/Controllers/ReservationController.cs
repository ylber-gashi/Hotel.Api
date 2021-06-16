using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ReservationCreateModel model)
        {
            return Ok(await _reservationService.CreateReservationAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _reservationService.GetAllReservationAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _reservationService.GetReservationByIdAsync(id));
        }
        
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _reservationService.DeleteAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ReservationUpdateModel model)
        {
            return Ok(await _reservationService.UpdateReservationAsync(model));
        }
    }
}
