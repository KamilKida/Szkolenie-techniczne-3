using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Payments.Entites
{
    [Table("Invoices", Schema = "Geo")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
