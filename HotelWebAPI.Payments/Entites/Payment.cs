using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Payments.Entites
{
    [Table("Payments", Schema = "Geo")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
