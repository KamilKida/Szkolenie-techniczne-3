using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Entites;
using HotelWebAPI.Reservations;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Payments.Services
{
    public class PaymentService
    {
        private readonly PaymentsDbContext _dbContext;

        public PaymentService(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> Add(AddPaymentDto dto)
        {
            var newPayment = new Payment()
            {
                ReservationId = dto.ReservationId,
                Amount = dto.Amount
            };

            await _dbContext.Payments.AddAsync(newPayment);
            await _dbContext.SaveChangesAsync();

            return newPayment;
        }
    }
}
