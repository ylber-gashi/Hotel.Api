using Hotel.Api.Application.Common.Models.RoomModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IRoomService
    {
        Task<int> CreateRoomAsync(RoomCreateModel model);
        Task<List<RoomListModel>> GetAllRoomsAsync();
        Task<RoomModel> GetRoomByIdAsync(int id);
        Task<RoomUpdateModel> UpdateRoomAsync(RoomUpdateModel model);
        Task<bool> DeleteAsync(int id);
        Task<int> AddRoomImagesAsync(int roomId, string imageURL);
    }
}
