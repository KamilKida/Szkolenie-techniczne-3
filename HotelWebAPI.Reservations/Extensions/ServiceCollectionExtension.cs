using HotelWebAPI.Main.Resolver;
using HotelWebAPI.Main.Services;

namespace HotelWebAPI.Main.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMainServices(this IServiceCollection services)
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
