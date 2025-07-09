using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Payments.Dtos
{
    public class AddRefundDto
    {
        [Required]
        public int ReservationId { get; set; }

        public string? Reason { get; set; }
    }
}
