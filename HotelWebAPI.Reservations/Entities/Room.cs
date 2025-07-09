using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HotelWebAPI.Reservations.Entities
{
    [Table("Rooms", Schema ="Geo")]
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NotNull]
        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; }

    }
}
