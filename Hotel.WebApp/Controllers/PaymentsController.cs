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
            var result = await _paymentService.GetAllPaymentsAsync();
            return View(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _paymentService.GetPaymentByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateModel model)
        {
            return Ok(await _paymentService.UpdatePaymentAsync(model));
        }
    }
}
