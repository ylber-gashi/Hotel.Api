using AutoMapper;
using Hotel.Api.Application.Common.Exceptions;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.RoomModels;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
            if (await CheckIfRoomNumberExists(model.RoomNumber))
            {
                throw new NotFoundException("Room", "Room doesn't exist");
            }
            var record = _mapper.Map<Room>(model);
            await _roomsRepository.InsertAsync(record);
            model.FirstImage.ForEach(async x => await _roomImageRepository.InsertAsync(new RoomImage { RoomId = record.Id, URL = x }));
            return record.Id;
        }

        public async Task<List<RoomListModel>> GetAllRoomsAsync()
        {
            var result = await _roomsRepository.GetAllAsync(query => query.Include(x => x.Images));
            return _mapper.Map<List<RoomListModel>>(result);
        }

        public async Task<RoomModel> GetRoomByIdAsync(int id)
        {
            var result = await _roomsRepository.GetAsync(query => query.Where(x => x.Id == id).Include(x => x.Images));
            if (result == null)
            {
                throw new NotFoundException("Room", "Room doesn't exist");
            }
            return _mapper.Map<RoomModel>(result);
        }

        public async Task<RoomUpdateModel> UpdateRoomAsync(RoomUpdateModel model)
        {
            var editeEntity = await _roomsRepository.GetByIdAsync(model.Id);
            if (editeEntity == null)
            {
                throw new NotFoundException("Room", "Room doesn't exist");
            }

            editeEntity.Capacity = model.Capacity;
            editeEntity.FloorNumber = model.FloorNumber;
            editeEntity.Price = model.Price;

            _roomsRepository.Update(editeEntity);

            foreach (var item in model.ImageURL)
            {
                var check = await _roomImageRepository.GetAsync(query => query.Where(x => x.RoomId == model.Id && x.URL == item));
                if (check == null)
                {
                    await _roomImageRepository.InsertAsync(new RoomImage { RoomId = model.Id, URL = item });
                }
            }

            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _roomsRepository.GetByIdAsync(id);
            if (deletedEntity != null)
            {
                await _roomsRepository.DeleteAsync(deletedEntity);
                return true;
            }
            return false;
        }

        public async Task<int> AddRoomImagesAsync(int roomId, string imageURL)
        {
            var room = await _roomsRepository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new NotFoundException("Room", "Room doesn't exist");
            }

            await _roomImageRepository.InsertAsync(new RoomImage() { RoomId = roomId, URL = imageURL });
            return roomId;
        }

        public async Task<bool> CheckIfRoomNumberExists(int roomNumber)
        {
            var result = await _roomsRepository.GetAsync(query => query.Where(x => x.RoomNumber == roomNumber));
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<int>> GetAllRoomIdsAsync()
        {
            var result = await _roomsRepository.GetAllAsync();
            return result.Select(x => x.Id).ToList();
        }
    }
}
