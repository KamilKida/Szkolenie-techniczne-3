using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Main.Entities
{
    [Table("Discounts", Schema ="Geo")]
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RequiredAmountOfVisits { get; set; }

        [Required]
        public decimal DiscountAmount {  get; set; }

        [Required]
        public bool IsPromotion { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = false;

    }
}
