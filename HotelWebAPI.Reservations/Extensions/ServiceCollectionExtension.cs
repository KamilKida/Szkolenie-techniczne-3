using HotelWebAPI.Reservations.Resolver;
using HotelWebAPI.Reservations.Services;

namespace HotelWebAPI.Reservations.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddReservationServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ReservationsDbContext, ReservationsDbContext>();
            services.AddScoped<ReservationSeeder>();

            services.AddTransient<UserService>();
            services.AddTransient<ReservationService>();
            services.AddTransient<DiscountService>();

            services.AddTransient<PaymentResolver>();

            return services;
        }
    }
}
