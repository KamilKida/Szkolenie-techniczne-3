using HotelWebAPI.Main.Dtos;
using HotelWebAPI.Main.Entities;
using HotelWebAPI.Main.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Main.Controllers
{
    [Route("hotelReservation/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountService _discountService;

        public DiscountController(DiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddDiscountDto dto)
        {
            var result = await _discountService.Add(dto);

            if (result.Item1 == null)
            {
                return BadRequest(result.Item2);
            }

            return Ok(result.Item1);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditDiscountDto dto)
        {
            var result = await _discountService.Edit(dto);

            if (result.Item1 == null)
            {
                return BadRequest(result.Item2);
            }

            return Ok(result.Item1);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _discountService.Delete(id);

            if (!result)
            {
                return NotFound("Discount not found.");
            }

            return Ok("Discount has been successfully deleted.");
        }
    }
}
