using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PaymentCreateModel model)
        {
            return Ok(await _paymentService.CreatePaymentAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _paymentService.GetAllPaymentsAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _paymentService.GetPaymentByIdAsync(id));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _paymentService.DeleteAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateModel model)
        {
            return Ok(await _paymentService.UpdatePaymentAsync(model));
        }
    }
}
