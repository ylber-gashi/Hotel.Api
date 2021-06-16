using AutoMapper;
using Hotel.Api.Application.Common.Models.Payment;
using Hotel.Api.Application.Common.Models.Reservation;
using Hotel.Api.Application.Common.Models.Room;
using Hotel.Api.Domain.Entities;

namespace Hotel.Api.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region RoomMapping
            CreateMap<Room, RoomListModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();
            CreateMap<Room, RoomUpdateModel>().ReverseMap();
            CreateMap<Room, RoomCreateModel>().ReverseMap();
            #endregion

            #region PaymentMapping
            CreateMap<Payment, PaymentCreateModel>().ReverseMap();
            CreateMap<Payment, PaymentModel>().ReverseMap();
            CreateMap<Payment, PaymentListModel>().ReverseMap();
            CreateMap<Payment, PaymentUpdateModel>().ReverseMap();
            #endregion

            #region Reservation
            CreateMap<Reservation, ReservationCreateModel>().ReverseMap();
            CreateMap<Reservation, ReservationModel>().ReverseMap();
            CreateMap<Reservation, ReservationListModel>().ReverseMap();
            CreateMap<Reservation, ReservationUpdateModel>().ReverseMap();
            #endregion
        }
    }
}
