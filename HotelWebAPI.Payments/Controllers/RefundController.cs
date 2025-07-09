using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Payments.Controllers
{
    [Route("hotelPayment/refund")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private readonly RefundService _refundService;

        public RefundController(RefundService refundService)
        {
            _refundService = refundService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddRefundDto dto)
        {
            var result = await _refundService.Add(dto);

            return Ok(result);
        }
    }
}
