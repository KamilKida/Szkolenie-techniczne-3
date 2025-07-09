using HotelWebAPI.Payments.Dtos;
using HotelWebAPI.Payments.Entites;
using HotelWebAPI.Reservations;

namespace HotelWebAPI.Payments.Services
{
    public class InvoiceService
    {
        private readonly PaymentsDbContext _dbContext;

        public InvoiceService(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Invoice> Add(AddInvoiceDto dto)
        {
            var newInvoice = new Invoice()
            {
                PaymentId = dto.PaymentId,
                UserId = dto.UserId
            };

            await _dbContext.Invoices.AddAsync(newInvoice);
            await _dbContext.SaveChangesAsync();

            return newInvoice;
        }
    }
}
