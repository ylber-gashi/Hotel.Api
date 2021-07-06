using AutoMapper;
using Hotel.Api.Application.Common.Exceptions;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.PaymentModels;
using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IEntityRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IEntityRepository<Payment> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<int> CreatePaymentAsync(PaymentCreateModel model)
        {
            var record = _mapper.Map<Payment>(model);
            record.InsertDate = DateTime.Now;
            await _paymentRepository.InsertAsync(record);
            return record.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _paymentRepository.GetByIdAsync(id);
            if (deletedEntity == null)
            {
                throw new NotFoundException("Payment", "Payment not found");
            }

            await _paymentRepository.DeleteAsync(deletedEntity);
            return true;
        }

        public async Task<List<PaymentModel>> GetAllPaymentsAsync()
        {
            var result = await _paymentRepository.GetAllAsync(query => query.Include(x => x.User));
            return _mapper.Map<List<PaymentModel>>(result);
        }

        public async Task<PaymentModel> GetPaymentByIdAsync(int id)
        {
            var result = await _paymentRepository.GetAsync(query => query.Where(x => x.Id == id).Include(x => x.Reservations).ThenInclude(x => x.Room));
            if (result == null)
            {
                throw new NotFoundException("Payment", "Payment not found");
            }
            return _mapper.Map<PaymentModel>(result);
        }

        public async Task<PaymentUpdateModel> UpdatePaymentAsync(PaymentUpdateModel model)
        {
            var editeEntity = await _paymentRepository.GetByIdAsync(model.Id);
            if (editeEntity == null)
            {
                throw new NotFoundException("Payment", "Payment not found");
            }

            editeEntity.Price = model.Total;
            editeEntity.UpdateDate = DateTime.Now;
            _paymentRepository.Update(editeEntity);
            return model;
        }
    }
}
