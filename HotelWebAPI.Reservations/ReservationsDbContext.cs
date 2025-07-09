using Microsoft.EntityFrameworkCore;
using HotelWebAPI.Reservations.Entities;

namespace HotelWebAPI.Reservations
{
    public class ReservationsDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<UserReservation> UserReservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Discount> Discounts { get; set; }


        public ReservationsDbContext(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=hotel-reservations-project;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ST3 Projekt"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
