using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Entites;
using HotelWebAPI.Reservations;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Payments.Services
{
    public class RefundService 
    {
        private readonly PaymentsDbContext _dbContext;

        public RefundService(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Refund> Add(AddRefundDto dto)
        {
            var paymentToRefund = await _dbContext.Payments.
                FirstOrDefaultAsync(p => p.ReservationId == dto.ReservationId);

            if (paymentToRefund == null) return default;

            var newRefund = new Refund()
            {
                Reason = dto.Reason,
                PaymentId = paymentToRefund.Id
            };

            await _dbContext.Refunds.AddAsync(newRefund);
            await _dbContext.SaveChangesAsync();

            return newRefund;
        }
    }
}
