using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Main.Entities
{
    [Table("Users", Schema ="Geo")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string? FullName { get; set; }
        [Required]
        public int AmountOfVisits { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<UserReservation> Reservations { get; set; } = new List<UserReservation>();
    }
}
