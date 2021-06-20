using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.RoomModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hotel.Api.Domain.Enumerations;
using System.Collections.Generic;

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
            var rooms = new List<RoomModel>()
            {
                new RoomModel
            {
                Id = 1,
                RoomNumber = 2,
                RoomType = RoomTypes.NORMAL,
                FloorNumber = 4,
                Capacity = 4,
                Price = 50,
                Images = new List<string>
                {
                    "https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg"
                }
            },
                new RoomModel
            {
                Id = 1,
                RoomNumber = 2,
                RoomType = RoomTypes.NORMAL,
                FloorNumber = 4,
                Capacity = 4,
                Price = 50,
                Images = new List<string>
                {
                    "https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg"
                }
            }
        };
            return View(rooms);
        }

        [HttpGet("rooms/add")]
        public async Task<IActionResult> AddRoomView()
        {
            return View("AddRoom");
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomCreateModel roomModel)
        {
            //save room in db
            return RedirectToAction("AllRooms");
        }

        [HttpGet("rooms/{id}")]
        public async Task<IActionResult> SingleRoom(int id)
        {
            var roomModel = new RoomModel
            {
                Id = 1,
                RoomNumber = 2,
                RoomType = RoomTypes.NORMAL,
                FloorNumber = 4,
                Capacity = 4,
                Price = 50,
                Images = new List<string>
                {
                    "https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg"
                }
            };
            return View(roomModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(int roomId, string imageURL)
        {
            // The Images list of this room should be updated .Add(imageURL)
            return RedirectToAction("SingleRoom", new { id = 1 });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            return RedirectToAction("AllRooms");
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody] RoomUpdateModel model)
        //{
        //    return Ok(await _roomService.UpdateRoomAsync(model));
        //}
    }
}
