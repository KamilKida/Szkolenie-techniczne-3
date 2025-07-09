using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Payments.Entites
{
    [Table("Refunds", Schema = "Geo")]
    public class Refund
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int PaymentId { get; set; }
        
        public virtual Payment Payment { get; set; }

        public string? Reason { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
