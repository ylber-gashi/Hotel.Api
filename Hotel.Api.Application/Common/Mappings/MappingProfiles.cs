using AutoMapper;
using Hotel.Api.Application.Common.Models.Room;
using Hotel.Api.Domain.Entities;

namespace Hotel.Api.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Room, RoomListModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();
            CreateMap<Room, RoomUpdateModel>().ReverseMap();
            CreateMap<Room, RoomCreateModel>().ReverseMap();
        }
    }
}
