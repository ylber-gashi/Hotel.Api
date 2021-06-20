using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.PaymentModels;
using Hotel.Api.Application.Common.Models.ReservationModels;
using Hotel.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("payments")]
        public async Task<IActionResult> AllPayments()
        {
            var payments = new List<PaymentModel>()
            {
                new PaymentModel
                {
                    Id = 1,
                    UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                    FirstName = "Ylber",
                    LastName = "Gashi",
                    Price = 200,
                    Reservations = new List<ReservationModel>()
                    {
                        new ReservationModel
                        {
                            Id = 1,
                            UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                            FirstName = "Ylber",
                            LastName = "Gashi",
                            RoomId = 3,
                            RoomNumber = 4,
                            RoomPrice = 299,
                            CheckInDate = DateTime.Now,
                            CheckOutDate = DateTime.Now,
                            PaymentId = 3
                        },
                        new ReservationModel
                        {
                            Id = 1,
                            UserId = "2214347e-12c3-4c94-959a-aab3893a78ca",
                            FirstName = "Ylber",
                            LastName = "Gashi",
                            RoomId = 3,
                            RoomNumber = 4,
                            RoomPrice = 299,
                            CheckInDate = DateTime.Now,
                            CheckOutDate = DateTime.Now,
                            PaymentId = 3
                        },
                    }
                }
            };
            return View(payments);
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentCreateModel model)
        {
            // e pranon listen e reservationsId, userId dhe e llogarit price total per qato reservation. Pas kesaj ruhet payment ne database. Nuk ka me status isPayed ose PaymentMethod
            return null;
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    return Ok(await _paymentService.GetPaymentByIdAsync(id));
        //}

        //[HttpDelete("id")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    return Ok(await _paymentService.DeleteAsync(id));
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateModel model)
        //{
        //    return Ok(await _paymentService.UpdatePaymentAsync(model));
        //}
    }
}
