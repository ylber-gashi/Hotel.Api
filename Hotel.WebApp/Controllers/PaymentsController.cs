using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.PaymentModels;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("payments/{id}")]
        public async Task<IActionResult> AllPayments(string id)
        {
            var result = await _paymentService.GetAllPaymentsAsync(id);
            return View(result);
        }

        [HttpGet("payments/reservations/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);
            return View("../Reservations/AllReservations", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateModel model)
        {
            return Ok(await _paymentService.UpdatePaymentAsync(model));
        }
    }
}
