using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Payments.Dtos
{
    public class AddInvoiceDto
    {
        [Required]
        public int PaymentId { get; set; }

        [Required]
        public int UserId { get; set; }
}
}
