using HotelWebAPI.Main.Dtos;
using HotelWebAPI.Main.Entities;
using HotelWebAPI.Main.Services;
using HotelWebAPI.Payments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Main.Controllers
{
    [Route("hotelReservation/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddReservationDto dto)
        {
            var result = await _reservationService.Add(dto);

            if (result.Item1 == null)
            {
                return BadRequest(result.Item2);
            }

            return Ok(result.Item1);
        }

        [HttpPut("confirm/{id}")]
        public async Task<IActionResult> Confirm([FromRoute] int id)
        {
            var result = await _reservationService.ConfirmReservation(id);

            if (!result.Item1)
            {
                return BadRequest(result.Item2);
            }

            return Ok("Reservation has been confirmed.\n" + result.Item2);
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> Cancel([FromBody] AddRefundDto dto)
        {
            var result = await _reservationService.CancelReservation(dto);

            if (!result.Item1)
            {
                return NotFound(result.Item2);
            }

            return Ok("Reservation has been cancelled." + result.Item2);
        }
    }
}
