using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Payments.Dtos
{
    public class AddPaymentDto
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
