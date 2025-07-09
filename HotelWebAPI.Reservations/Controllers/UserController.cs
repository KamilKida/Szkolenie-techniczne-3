using HotelWebAPI.Reservations.Dtos;
using HotelWebAPI.Reservations.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Reservations.Controllers
{
    [Route("hotelReservation/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.Add(dto);
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserDto dto)
        {
            var result = await _userService.Edit(dto);
            if (result == null)
            {
                return NotFound("Couldn't find user.");
            }
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.Delete(id);
            if (!result)
            {
                return NotFound("Couldn't find user.");
            }
            return Ok("User deleted.");
        }
    }
}
