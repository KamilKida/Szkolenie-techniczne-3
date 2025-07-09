using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Main.Entities
{
    [Table("UserReservations", Schema = "Geo")]
    public class UserReservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [ForeignKey(nameof(Discount))]
        public int? DiscountId { get; set; }

        public virtual Discount? Discount { get; set; }

        [Required]
        public DateTime ReservedFrom { get; set; }

        [Required]
        public DateTime ReservedTo { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Confirmed { get; set; } = false;
    }
}
