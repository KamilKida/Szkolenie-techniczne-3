using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Payments.Controllers
{
    [Route("hotelPayment/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddInvoiceDto dto)
        {
            var result = await _invoiceService.Add(dto);

            return Ok(result);
        }
    }
}
