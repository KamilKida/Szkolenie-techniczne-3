using Microsoft.EntityFrameworkCore;
using HotelWebAPI.Payments.Entites;

namespace HotelWebAPI.Reservations
{
    public class PaymentsDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Payment> Payments  { get; set; }
        public DbSet<Invoice>Invoices { get; set; }
        public DbSet<Refund> Refunds { get; set; }


        public PaymentsDbContext(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=hotel-payments-project;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ST3 Projekt"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
