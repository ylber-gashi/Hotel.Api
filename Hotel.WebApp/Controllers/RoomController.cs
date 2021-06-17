using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.Room;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RoomCreateModel model)
        {
            return Ok(await _roomService.CreateRoomAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _roomService.GetAllRoomsAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _roomService.GetRoomByIdAsync(id));
        }
        
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _roomService.DeleteAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomUpdateModel model)
        {
            return Ok(await _roomService.UpdateRoomAsync(model));
        }
    }
}
