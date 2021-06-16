using AutoMapper;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.Reservation;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEntityRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IEntityRepository<Reservation> reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateReservationAsync(ReservationCreateModel model)
        {
            var record = _mapper.Map<Reservation>(model);
            await _reservationRepository.InsertAsync(record);
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
            return false;
        }

        public async Task<List<ReservationListModel>> GetAllReservationAsync()
        {
            try
            {
                var result = await _reservationRepository.GetAllAsync(query => query.Include(x => x.User));
                if (result == null)
                {
                    throw new Exception("No payments yet!");
                }
                return _mapper.Map<List<ReservationListModel>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReservationModel> GetReservationByIdAsync(int id)
        {
            try
            {
                var result = await _reservationRepository.GetAsync(query => query.Where(x => x.Id == id));
                if (result == null)
                {
                    throw new Exception("Room doesn't exist");
                }
                return _mapper.Map<ReservationModel>(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ReservationUpdateModel> UpdateReservationAsync(ReservationUpdateModel model)
        {
            try
            {
                var editeEntity = await _reservationRepository.GetByIdAsync(model.Id);
                if (editeEntity == null)
                {
                    throw new Exception("Entity doesn't exist");
                }


                _reservationRepository.Update(editeEntity);
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}
