using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Main.Dtos
{
    public class AddReservationDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime ReservedFrom { get; set; }

        [Required]
        public DateTime ReservedTo { get; set; }

    }
}
