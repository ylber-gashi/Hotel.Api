using AutoMapper;
using Hotel.Api.Application.Common.Exceptions;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.PaymentModels;
using Hotel.Api.Application.Common.Models.ReservationModels;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEntityRepository<Reservation> _reservationRepository;
        private readonly IPaymentService _paymentService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public ReservationService(IEntityRepository<Reservation> reservationRepository, IMapper mapper, IPaymentService paymentService, IRoomService roomService = null)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _paymentService = paymentService;
            _roomService = roomService;
        }

        public async Task<int> CreateReservationAsync(ReservationCreateModel model)
        {
            var paymentId = await _paymentService.CreatePaymentAsync(new PaymentCreateModel { UserId = model.UserId });

            var record = _mapper.Map<Reservation>(model);
            record.PaymentId = paymentId;
            await _reservationRepository.InsertAsync(record);
            
            var roomPrice = await _roomService.GetRoomByIdAsync(model.RoomId);
            var updatePayment = await _paymentService.UpdatePaymentAsync(new PaymentUpdateModel { Id = paymentId, Total = roomPrice.Price });
            
            return record.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _reservationRepository.GetByIdAsync(id);
            if (deletedEntity != null)
            {
                await _reservationRepository.DeleteAsync(deletedEntity);
                return true;
            }
            throw new NotFoundException("Reservation", "Reservation doesn't exist");
        }

        public async Task<List<ReservationModel>> GetAllReservationAsync()
        {
            var result = await _reservationRepository.GetAllAsync(query => query.Include(x => x.User));
            return _mapper.Map<List<ReservationModel>>(result);
        }

        public async Task<ReservationModel> GetReservationByIdAsync(int id)
        {
            var result = await _reservationRepository.GetAsync(query => query.Where(x => x.Id == id));
            if (result == null)
            {
                throw new NotFoundException("Reservation", "Reservation doesn't exist");
            }
            return _mapper.Map<ReservationModel>(result);
        }

        public async Task<ReservationUpdateModel> UpdateReservationAsync(ReservationUpdateModel model)
        {
            var editEntity = await _reservationRepository.GetByIdAsync(model.Id);
            if (editEntity == null)
            {
                throw new NotFoundException("Reservation", "Reservation not found");
            }

            _reservationRepository.Update(editEntity);
            return model;
        }
    }
}
