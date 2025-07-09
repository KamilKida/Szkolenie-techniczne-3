using HotelWebAPI.Payments.Services;
using HotelWebAPI.Reservations;

namespace HotelWebAPI.Payments.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPaymentServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<PaymentsDbContext, PaymentsDbContext>();

            services.AddTransient<PaymentService>();
            services.AddTransient<InvoiceService>();
            services.AddTransient<RefundService>();

            return services;
        }
    }
}
