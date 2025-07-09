using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Entites;
using HotelWebAPI.Payments.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Payments.Controllers
{
    [Route("hotelPayment/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddPaymentDto dto)
        {
            var result = await _paymentService.Add(dto);

            return Ok(result);
        }
    }
}
