using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Main.Dtos
{
    public class AddDiscountDto
    {
        [Required]
        public int RequiredAmountOfVisits { get; set; }

        [Required]
        public decimal DiscountAmount { get; set; }

        [Required]
        public bool IsPromotion { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
