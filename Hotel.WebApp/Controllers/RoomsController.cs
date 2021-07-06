using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.RoomModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("rooms")]
        public async Task<IActionResult> AllRooms()
        {
            return View(await _roomService.GetAllRoomsAsync());
        }

        [HttpGet("rooms/add")]
        public async Task<IActionResult> AddRoomView()
        {
            return View("AddRoom");
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomCreateModel roomModel)
        {
            var result = await _roomService.CreateRoomAsync(roomModel);
            return RedirectToAction("SingleRoom", new { id = result });
        }

        [HttpGet("rooms/{id}")]
        public async Task<IActionResult> SingleRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            return View(room);
        }

        [HttpPost("images")]
        public async Task<IActionResult> AddImage(int roomId, string imageURL)
        {
            var result = await _roomService.AddRoomImagesAsync(roomId, imageURL);
            return RedirectToAction("SingleRoom", new { id = result });
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            var result = await _roomService.DeleteAsync(roomId);
            if (result)
            {
                return RedirectToAction("AllRooms");
            }
            return BadRequest(roomId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomUpdateModel model)
        {
            return Ok(await _roomService.UpdateRoomAsync(model));
        }
    }
}
