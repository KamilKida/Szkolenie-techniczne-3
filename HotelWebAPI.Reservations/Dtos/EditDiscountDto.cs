using System.ComponentModel.DataAnnotations;

namespace HotelWebAPI.Reservations.Dtos
{
    public class EditDiscountDto
    {
        [Required]
        public int Id { get; set; }
        public int? RequiredAmountOfVisits { get; set; }

        public decimal? DiscountAmount { get; set; }

        public bool? IsPromotion { get; set; }

        public bool? IsActive { get; set; }
    }
}
