using AutoMapper;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.Room;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IEntityRepository<Room> _roomsRepository;
        private readonly IEntityRepository<RoomImage> _roomImageRepository;
        private readonly IMapper _mapper;

        public RoomService(IEntityRepository<Room> roomRepository, IMapper mapper, IEntityRepository<RoomImage> roomImageRepository)
        {
            _roomsRepository = roomRepository;
            _roomImageRepository = roomImageRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateRoomAsync(RoomCreateModel model)
        {
            var record = _mapper.Map<Room>(model);
            await _roomsRepository.InsertAsync(record);
            model.Images.ForEach(x => _roomImageRepository.InsertAsync(new RoomImage { RoomId = record.Id, URL = x }).GetAwaiter().GetResult());
            return record.Id;
        }

        public async Task<List<RoomListModel>> GetAllRoomsAsync()
        {
            var result = await _roomsRepository.GetAllAsync();
            return _mapper.Map<List<RoomListModel>>(result);
        }

        public async Task<RoomModel> GetRoomByIdAsync(int id)
        {
            var result = await _roomsRepository.GetAsync(query => (IQueryable<Room>)query.Where(x => x.Id == id).Include(x => x.Images).SingleOrDefault());
            return _mapper.Map<RoomModel>(result);
        }

        public async Task<RoomUpdateModel> UpdateRoomAsync(RoomUpdateModel model)
        {
            try
            {
                var editeEntity = await _roomsRepository.GetByIdAsync(model.Id);
                if (editeEntity == null)
                {
                    throw new System.Exception("Entity doesn't exist");
                }

                editeEntity.Capacity = model.Capacity;
                editeEntity.FloorNumber = model.FloorNumber;
                editeEntity.RoomNumber = model.RoomNumber;
                editeEntity.Price = model.Price;

                _roomsRepository.Update(editeEntity);
            }
            catch
            {
                throw;
            }
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _roomsRepository.GetByIdAsync(id);
            await _roomsRepository.DeleteAsync(deletedEntity);
            return true;
        }
    }
}
