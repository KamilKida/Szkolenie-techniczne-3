using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Main.Dtos
{
    public class AddUserDto
    {
        [MaxLength(200)]
        public string? FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
